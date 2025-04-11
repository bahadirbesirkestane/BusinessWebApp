using Business.BusinessLayer.Abstract;
using Business.BusinessLayer.Concrete;
using Business.Consumers;
using Business.DataAccessLayer.Abstact;
using Business.DataAccessLayer.Context;
using Business.DataAccessLayer.EntityFramework;
using Business.DataAccessLayer.Repositories;
using Business.MessageBrokers;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IGenericDAL<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IAdminDAL), typeof(EfAdminRepository));
builder.Services.AddScoped(typeof(ICategoryDAL), typeof(EfCategoryRepository));
builder.Services.AddScoped(typeof(ICommentDAL), typeof(EfCommentRepository));
builder.Services.AddScoped(typeof(IMessageDAL), typeof(EfMessageRepository));
builder.Services.AddScoped(typeof(IPageDAL), typeof(EfPageRepository));
builder.Services.AddScoped(typeof(IProductDAL), typeof(EfProductRepository));
builder.Services.AddScoped(typeof(IProductImageDAL), typeof(EfProductImageRepository));


builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

builder.Services.AddScoped<IAdminService, AdminManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<IMessageService, MessageManager>();
builder.Services.AddScoped<IPageService, PageManager>();
builder.Services.AddScoped<IProductImageService, ProductImageManager>();
builder.Services.AddScoped<IProductService, ProductManager>();


builder.Services.AddDbContext<BusinessDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Masstansit
/////////////////////////////////////////

// MassTransit ve RabbitMQ yapýlandýrmasý
builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<MessageConsumer>(); // Consumer ekleme
    config.AddConsumer<ProductConsumer>(); // Consumer ekleme


    config.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("message-queue", e =>
        {
            e.ConfigureConsumer<MessageConsumer>(context);
            e.ConfigureConsumer<ProductConsumer>(context);
        });
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
