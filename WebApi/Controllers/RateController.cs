using BlogPost.Application.Common.DTOs.Rate;
using BlogPost.Application.Features.Rate.Requests.Queries;
using BlogPost.Application.Features.Rates.Requests.Commands;
using BlogPost.Application.Features.Rates.Requests.Queries;
using BlogPost.Application.Responses;
using BlogPost.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RatesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public RatesController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
        _mediator = mediator;
        this._httpContextAccessor = httpContextAccessor;
    }

    // GET: api/<RatesController>
    [HttpGet]
    public async Task<ActionResult<List<Rate>>> GetAll()
    {
        var Rates = await _mediator.Send(new GetRateListRequest());
        return Ok(Rates);
    }


    // GET api/<RatesController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<RateDto>> Get(int id)
    {
        var Rate = await _mediator.Send(new GetRateRequest { Id = id });
        return Ok(Rate);
    }

    // POST api/<RatesController>
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<BaseCommandResponse>> Rate([FromBody] CreateRateDTO Rate)
    {
        var user = _httpContextAccessor.HttpContext.User;
        var command = new CreateRateCommand { RateDto = Rate };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    // PUT api/<RatesController>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Put([FromBody] UpdateRateDTO Rate)
    {
        var command = new UpdateRateCommand { RateDto = Rate };
        await _mediator.Send(command);
        return NoContent();
    }

    // DELETE api/<RatesController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteRateCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
