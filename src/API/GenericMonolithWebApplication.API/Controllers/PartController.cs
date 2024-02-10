#nullable disable

using GenericMonolithWebApplication.Application.Features.Parts.Commands.CreatePart;
using GenericMonolithWebApplication.Application.Features.Parts.Commands.DeletePart;
using GenericMonolithWebApplication.Application.Features.Parts.Commands.UpdatePart;
using GenericMonolithWebApplication.Application.Features.Parts.Queries.GetPartsExport;
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

        [HttpPost(Name = "CreatePart")]
        public async Task<ActionResult<Guid>> CreatePart([FromBody] CreatePartCommand createPartCommand)
        {
            var response = await _mediator.Send(createPartCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdatePart")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdatePart([FromBody] UpdatePartCommand updatePartCommand)
        {
            await _mediator.Send(updatePartCommand);
            return NoContent();
        }

        [HttpDelete("{partId}", Name = "DeletePart")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeletePart(Guid partId)
        {
            var deletePartCommand = new DeletePartCommand() { PartId = partId };
            await _mediator.Send(deletePartCommand);
            return NoContent();
        }

        [HttpGet("export", Name = "ExportParts")]
        public async Task<FileResult> ExportParts()
        {
            var fileDto = await _mediator.Send(new GetPartsExportQuery());

            return File(fileDto.Data, fileDto.ContentType, fileDto.PartExportFileName);
        }
    }
}