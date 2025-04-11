using Business.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessLayer.ValidationRules
{
    public class PageValidator : AbstractValidator<Page>
    {
        public PageValidator()
        {
            RuleFor(x => x.PageTitle).NotEmpty().WithMessage("Başlık adı boş geçilemez!");
            RuleFor(x => x.PageTitle).MinimumLength(2).WithMessage("Başlık en az 2 karakter olamlıdır!");
            RuleFor(x => x.PageTitle).MaximumLength(100).WithMessage("Başlık en fazla 100 karakter olamlıdır!");

            RuleFor(x => x.PageContent).NotEmpty().WithMessage("İçerik boş geçilemez!");
            RuleFor(x => x.PageContent).MaximumLength(1000).WithMessage("İçerik en fazla 1000 karakter olamlıdır!");

            RuleFor(x => x.PageType).NotEmpty().WithMessage("Sayfa tipi tipi boş geçilemez!");
            RuleFor(x => x.PageType).MinimumLength(2).WithMessage("Sayfa tipi en az 2 karakter olamlıdır!");
            RuleFor(x => x.PageType).MaximumLength(100).WithMessage("Sayfa tipi en fazla 100 karakter olamlıdır!");
        }
    }
}
