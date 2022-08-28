using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.ContactMail).NotEmpty().WithMessage("Mail adresi boş geçilemez");
            RuleFor(x => x.ContactName).NotEmpty().WithMessage("İsim boş geçilemez.");
            RuleFor(x => x.ContactSubject).NotEmpty().WithMessage("Konu boş geçilemez.");
            RuleFor(x => x.ContactName).MinimumLength(3).WithMessage("En az 3 karakter girişi yapılmalıdır.");
            RuleFor(x => x.ContactSubject).MinimumLength(3).WithMessage("En az 3 karakter girişi yapılmalıdır.");
            RuleFor(x => x.ContactSubject).MaximumLength(50).WithMessage("En fazla 50 karakter girişi yapılabilir.");

        }

    }
}
