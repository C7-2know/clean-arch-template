using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BlogPost.Application.Common.DTOs.Rate;
using BlogPost.Application.Contracts.Persistence;

namespace BlogPost.Application.Common.DTOs.Rate.Validators;

public class CreateRateDtoValidator : AbstractValidator<CreateRateDTO>
{

    public CreateRateDtoValidator()
    {
        Include(new IRateDtoValidator());
    }
}

