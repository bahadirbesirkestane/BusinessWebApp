using Business.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessLayer.ValidationRules
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator() 
        {
            RuleFor(x => x.CommentUserName)
                .NotEmpty().WithMessage("İsim ve soyisim alanı zorunludur.")
                .MaximumLength(50).WithMessage("İsim ve soyisim en fazla 50 karakter olabilir.");

            RuleFor(x => x.CommentContent)
                .NotEmpty().WithMessage("Yorum alanı boş bırakılamaz.")
                .MaximumLength(500).WithMessage("Yorum en fazla 500 karakter olabilir.");

            RuleFor(x => x.CommentTitle)
               .NotEmpty().WithMessage("Başlık alanı boş bırakılamaz.")
               .MaximumLength(50).WithMessage("Başlık en fazla 50 karakter olabilir.");

        }
    }
}
