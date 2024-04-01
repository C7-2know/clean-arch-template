using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

using BlogPost.Application.Common.DTOs.Rate.Validators;
using BlogPost.Application.Common.Exceptions;
using BlogPost.Application.Features.Rates.Requests.Commands;
using BlogPost.Application.Contracts.Persistence;
using BlogPost.Application.Responses;
using BlogPost.Domain.Entities;
using BlogPost.Application.Features.Rates.Requests.Commands;

namespace Application.Features.Rates.Handlers.Commands;

public class CreateRateCommandHandler : IRequestHandler<CreateRateCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateRateCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(CreateRateCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new CreateRateDtoValidator();
        var validationResult = await validator.ValidateAsync(request.RateDto);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Rate creation Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        else
        {

            var Rate = _mapper.Map<Rate>(request.RateDto);

            Rate = await _unitOfWork.RateRepository.Add(Rate);
            await _unitOfWork.Save();
            
            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = Rate.Id;
        }
        return response;
    }
}

