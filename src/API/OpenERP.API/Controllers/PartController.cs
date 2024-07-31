#nullable disable

using OpenERP.API.Utility;
using OpenERP.Application.Features.Parts.Commands.CreatePart;
using OpenERP.Application.Features.Parts.Commands.DeletePart;
using OpenERP.Application.Features.Parts.Commands.UpdatePart;
using OpenERP.Application.Features.Parts.Queries.GetPartsExport;
using OpenERP.Application.Features.Parts.Queries.GetPartsList;
using OpenERP.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OpenERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public PartController(IMediator mediator, ILogger<PartController> logger)
        {
            _mediator = mediator;
            _logger = logger;
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
        [FileResultContentType("text/csv")]
        public async Task<FileResult> ExportParts()
        {
            var fileDto = await _mediator.Send(new GetPartsExportQuery());

            return File(fileDto.Data, fileDto.ContentType, fileDto.PartExportFileName);
        }
    }
}