using MediatR;
using System;

#nullable disable

namespace OpenERP.Application.Features.Parts.Commands.UpdatePart
{
    public class UpdatePartCommand : IRequest //no return type required for an update, as the API won't respond with anything if successful
    {
        public Guid PartId;
        public string PartNum { get; set;}
        public string PartDescription { get; set;}
    }
}