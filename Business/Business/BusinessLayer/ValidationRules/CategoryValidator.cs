using Business.Models.Concrete;
using FluentValidation;

namespace Business.BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator() 
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş geçilemez!");
            RuleFor(x => x.CategoryName).MinimumLength(5).WithMessage("İsim en az 5 karakter olamlıdır!");
            RuleFor(x => x.CategoryName).MaximumLength(100).WithMessage("İsim en fazla 100 karakter olamlıdır!");

            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklama boş geçilemez!");
            RuleFor(x => x.CategoryDescription).MaximumLength(50).WithMessage("Açıklama en fazla 100 karakter olamlıdır!");

            //RuleFor(x => x.CategoryStatus).NotEmpty().WithMessage("Blog Başlığı boş geçilemez!");

        }

    }
}
