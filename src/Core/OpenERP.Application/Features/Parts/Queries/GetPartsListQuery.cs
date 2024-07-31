using OpenERP.Application.ViewModels;
using MediatR;

namespace OpenERP.Application.Features.Parts.Queries.GetPartsList
{
    public class GetPartsListQuery : IRequest<IList<PartsViewModel>>
    {

    }
}