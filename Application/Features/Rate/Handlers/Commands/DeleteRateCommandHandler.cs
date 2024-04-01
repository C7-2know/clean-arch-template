using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

using BlogPost.Application.Common.DTOs.Rate.Validators;
using BlogPost.Application.Common.Exceptions;
using BlogPost.Application.Features.Rates.Requests.Commands;
using BlogPost.Application.Contracts.Persistence;
using BlogPost.Application.Responses;
using BlogPost.Domain.Entities;

namespace BlogPost.Application.Features.Rates.Handlers.Commands;

public class DeleteRateCommandHandler : IRequestHandler<DeleteRateCommand,BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteRateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(DeleteRateCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var Rate = await _unitOfWork.RateRepository.Get(request.Id);
        response.Id = request.Id; 
        if (Rate == null){
            response.Success = false;
            response.Message = "Rate Update Failed";
            response.Errors = new List<string>{
                "Rate not found"
            };
        }else{
            await _unitOfWork.RateRepository.Delete(Rate);
            await _unitOfWork.Save();
            response.Success = true;
            response.Message = "Rate Deleted";   
        }   
        return response;
    }
}

