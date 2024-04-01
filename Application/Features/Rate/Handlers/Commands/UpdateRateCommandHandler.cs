using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using BlogPost.Application.Common.DTOs.Rate.Validators;
using BlogPost.Application.Common.Exceptions;
using BlogPost.Application.Features.Rate.Requests.Commands;
using BlogPost.Application.Contracts.Persistence;
using BlogPost.Application.Responses;
using BlogPost.Domain.Entities;

namespace Application.Features.Rates.Handlers.Commands;

public class UpdateRateCommandHandler : IRequestHandler<UpdateRateCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateRateCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(UpdateRateCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new UpdateRateDtoValidator();
        var validationResult = await validator.ValidateAsync(request.RateDto);

        if (validationResult.IsValid == false){

            response.Success = false;
            response.Message = "Rate Update Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

        }else{

            var Rate = await _unitOfWork.RateRepository.Get(request.RateDto.Id);
            if (Rate is null){
                response.Success = false;
                response.Message = "Rate Update Failed";
                response.Errors = new List<string>{
                    "Rate not found"
                };
            }else{
                _mapper.Map(request.RateDto, Rate);
                await _unitOfWork.RateRepository.Update(Rate);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = Rate.Id;
            }
        }
        return response;
    }
}

