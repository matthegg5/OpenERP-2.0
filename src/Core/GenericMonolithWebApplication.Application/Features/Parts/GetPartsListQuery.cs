using GenericMonolithWebApplication.Application.ViewModels;
using MediatR;

namespace GenericMonolithWebApplication.Application.Features.Parts.Queries.GetPartsList
{
    public class GetPartsListQuery : IRequest<IList<PartsList>>
    {

    }
}