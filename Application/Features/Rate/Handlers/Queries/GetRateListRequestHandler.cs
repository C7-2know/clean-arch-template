using AutoMapper;
using BlogPost.Application.Common.DTOs.Rate;
using BlogPost.Application.Contracts.Persistence;
using BlogPost.Application.Features.Rate.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace BlogPost.Application.Features.Rate.Handlers.Queries;
public class GetRateListRequestHandler : IRequestHandler<GetRateListRequest,List<RateDto>>
{
    private readonly IRateRepository _RateRepository;
    private readonly IMapper _mapper;
    public GetRateListRequestHandler(IRateRepository rateRepository,IMapper mapper)
    {
        _RateRepository=rateRepository;
        _mapper=mapper;
    }
    public async Task<List<RateDto>> Handle(GetRateListRequest request,CancellationToken cancellationToken)
    {
        var rates=await _RateRepository.GetAll();
        return _mapper.Map<List<RateDto>>(rates);
    }
}