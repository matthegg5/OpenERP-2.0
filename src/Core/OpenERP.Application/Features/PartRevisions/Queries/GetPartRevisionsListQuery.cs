using OpenERP.Application.ViewModels;
using MediatR;

namespace OpenERP.Application.Features.Parts.Queries.GetPartRevisionsList
{
    public class GetPartRevisionsListQuery : IRequest<PartRevisionsViewModel>
    {
        public Guid PartId { get; set;}
    }
}