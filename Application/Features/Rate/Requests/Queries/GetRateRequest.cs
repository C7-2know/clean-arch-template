using BlogPost.Application.Common.DTOs.Rate;
using MediatR;

namespace BlogPost.Application.Features.Rate.Requests.Queries;
public class GetRateRequest : IRequest<RateDto>
{

}