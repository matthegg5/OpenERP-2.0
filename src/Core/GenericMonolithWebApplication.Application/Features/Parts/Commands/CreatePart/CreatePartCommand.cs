using MediatR;

namespace GenericMonolithWebApplication.Application.Features.Parts.Commands.CreatePart
{
    public class CreatePartCommand : IRequest<Guid>
    {
        public string PartNum { get; set;}
        public string PartDescription { get; set;}
        public override string ToString()
        {
            return $"Part: {PartNum}, Descrption: {PartDescription}";
        }
    }
}