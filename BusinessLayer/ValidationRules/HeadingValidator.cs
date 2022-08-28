using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class HeadingValidator : AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage("Başlık adı boş geçilemez.");
            RuleFor(x => x.HeadingName).MaximumLength(50).WithMessage("Başlık adı en fazla 50 karakter olabilir.");
        }
    }
}
