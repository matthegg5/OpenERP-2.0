using GenericMonolithWebApplication.Application.ViewModels;
using MediatR;

namespace GenericMonolithWebApplication.Application.Features.Parts.Queries.GetPartRevisionsList
{
    public class GetPartRevisionsListQuery : IRequest<PartRevisionsViewModel>
    {
        public Guid PartId { get; set;}
    }
}