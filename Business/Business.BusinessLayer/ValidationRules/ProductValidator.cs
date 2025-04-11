using Business.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessLayer.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün adı boş geçilemez!");
            RuleFor(x => x.ProductName).MinimumLength(2).WithMessage("İsim en az 2 karakter olamlıdır!");
            RuleFor(x => x.ProductName).MaximumLength(50).WithMessage("İsim en fazla 50 karakter olamlıdır!");

            RuleFor(x => x.ProductDescription).NotEmpty().WithMessage("Ürün açıklaması boş geçilemez!");
            RuleFor(x => x.ProductDescription).MinimumLength(2).WithMessage("Açıklama en az 2 karakter olamlıdır!");
            RuleFor(x => x.ProductDescription).MaximumLength(250).WithMessage("Açıklama en fazla 250 karakter olamlıdır!");

            RuleFor(x => x.ProductPrice)
                .NotEmpty().WithMessage("Ürün fiyatı boş geçilemez!")
                .GreaterThan(0).WithMessage("Ürün fiyatı 0'dan büyük olmalıdır!")
                .LessThan(1000000).WithMessage("Ürün fiyatı 1.000.000’dan küçük olmalıdır!");
            RuleFor(x => x.ProductPrice)
                .Must(x => decimal.TryParse(x.ToString(), out _))
                .WithMessage("Ürün fiyatı geçerli bir sayı olmalıdır!");

            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Ürün kategorisi boş geçilemez!");



        }

    }
}
