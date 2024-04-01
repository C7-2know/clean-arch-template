using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using BlogPost.Application.Responses;
using BlogPost.Application.Common.DTOs.Rate;

namespace BlogPost.Application.Features.Rates.Requests.Commands;

public class CreateRateCommand : IRequest<BaseCommandResponse>
{
    public CreateRateDTO RateDto { get; set; }
}

