using MediatR;

namespace GenericMonolithWebApplication.Application.Features.Parts.Commands.DeletePart
{
    public class DeletePartCommand : IRequest  //no return type required for an update, as the API won't respond with anything if successful
    {
        public Guid PartId { get; set; }
    }
}