using Business.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş geçilemez!");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("İsim en az 2 karakter olamlıdır!");
            RuleFor(x => x.CategoryName).MaximumLength(100).WithMessage("İsim en fazla 100 karakter olamlıdır!");

            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklama boş geçilemez!");
            RuleFor(x => x.CategoryDescription).MaximumLength(50).WithMessage("Açıklama en fazla 100 karakter olamlıdır!");

            //RuleFor(x => x.CategoryStatus).NotEmpty().WithMessage("Blog Başlığı boş geçilemez!");

        }

    }
}
