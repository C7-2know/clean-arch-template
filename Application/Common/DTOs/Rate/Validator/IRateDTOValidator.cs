using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BlogPost.Application.Common.DTOs.Rate;

namespace BlogPost.Application.Common.DTOs.Rate.Validators
{
    public class IRateDtoValidator : AbstractValidator<RateDto>
    {
        public IRateDtoValidator()
        {
            RuleFor(r => r.Value)
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .WithMessage("The value must be an integer greater than or equal to 0.");
        }
    }
}