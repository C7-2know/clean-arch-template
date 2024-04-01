using BlogPost.Application.Common.DTOs.Rate;
using MediatR;

namespace BlogPost.Application.Features.Rate.Requests.Queries;
public class GetRateListRequest : IRequest<List<RateDto>>
{

}