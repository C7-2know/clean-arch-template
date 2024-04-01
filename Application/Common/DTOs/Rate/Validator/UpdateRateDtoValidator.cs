using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BlogPost.Application.Common.DTOs.Rate;

using BlogPost.Application.Common.DTOs.Rate;
using BlogPost.Application.Common.DTOs.Rate.Validators;

namespace BlogPost.Application.Common.DTOs.Rate.Validators;

public class UpdateRateDtoValidator : AbstractValidator<UpdateRateDTO>
{

    public  UpdateRateDtoValidator()
    {
        Include(new IRateDtoValidator());
    }
}

