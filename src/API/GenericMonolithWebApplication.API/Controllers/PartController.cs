using GenericMonolithWebApplication.Application.Features.Parts.Commands.CreatePart;
using GenericMonolithWebApplication.Application.Features.Parts.Queries.GetPartsList;
using GenericMonolithWebApplication.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GenericMonolithWebApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllParts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PartsViewModel>>> GetAllParts()
        {
            var queryResponse = await _mediator.Send(new GetPartsListQuery());
            return Ok(queryResponse);
        }

        [HttpPost(Name = "AddPart")]
        public async Task<ActionResult<Guid>> CreatePart([FromBody] CreatePartCommand createPartCommand)
        {
            var response = await _mediator.Send(createPartCommand);
            return Ok(response);
        }
    }
}