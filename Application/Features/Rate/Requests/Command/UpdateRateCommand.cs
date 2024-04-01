using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using BlogPost.Application.Common.DTOs.Rate;
using BlogPost.Application.Responses;

namespace BlogPost.Application.Features.Rates.Requests.Commands;

public class UpdateRateCommand : IRequest<BaseCommandResponse>
{
    public UpdateRateDTO RateDto { get; set; }
}

