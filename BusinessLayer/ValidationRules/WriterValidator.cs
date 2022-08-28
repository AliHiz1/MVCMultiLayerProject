using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş geçilemez.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Yazar hakkında açıklama yapmanız gerekmektedir.");
            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("En az 3 karakter girişi yapılmalıdır.");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("En fazla 50 karakter girişi yapılabilir.");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadı boş geçilemez.");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Yazarın mail adresinin girilmesi gerekmektedir.");
            RuleFor(x => x.WriterSurname).MinimumLength(3).WithMessage("Soyadı için en az 3 karakter girişi yapılmalıdır.");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Soyadı için en fazla 50 karakter girişi yapılabilir.");
        }
    }
}
