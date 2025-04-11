using Business.DataAccessLayer.Context;
using Business.EntityLayer.Concrete;
using Business.Producer;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Business.MessageBrokers
{
    public class ProductConsumer : IConsumer<ProductCreatedEvent>
    {
        private readonly BusinessDbContext _context;

        public ProductConsumer(BusinessDbContext context)
        {
            _context = context;
        }

        public async Task Consume(ConsumeContext<ProductCreatedEvent> context)
        {
            var productEvent = context.Message;

            var product = new Product
            {
                ProductName = productEvent.Name,
                ProductPrice = productEvent.Price,
                ProductDescription= productEvent.Description,
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
    }
}
