using Business.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.CustomerName)
                .NotEmpty().WithMessage("İsim ve soyisim alanı zorunludur.")
                .MaximumLength(50).WithMessage("İsim ve soyisim en fazla 50 karakter olabilir.");

            RuleFor(x => x.CustomerMessage)
                .NotEmpty().WithMessage("Mesaj alanı boş bırakılamaz.")
                .MaximumLength(500).WithMessage("Mesaj en fazla 500 karakter olabilir.");

            RuleFor(x => x.CustomerEmail)
                .NotEmpty().WithMessage("Mail adresi zorunludur.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

            RuleFor(x => x.CustomerPhone)
                .NotEmpty().WithMessage("Telefon numarası zorunludur.")
                .Matches(@"^(?:\+90|0)\d{10}$").WithMessage("Telefon numarası +90 veya 0 ile başlamalı ve 10 haneli olmalıdır.");

            RuleFor(x => x.AdminReply)
               .NotEmpty().WithMessage("Admin mesajı zorunludur.");

        }

    }
}
