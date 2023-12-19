using MediatR;
using GenericMonolithWebApplication.Application.Contracts.Persistence;
using AutoMapper;
using GenericMonolithWebApplication.Domain.Entities;
using GenericMonolithWebApplication.Application.ViewModels;

namespace GenericMonolithWebApplication.Application.Features.Parts.Queries.GetPartsList
{
    public class GetPartsListQueryHandler : IRequestHandler<GetPartsListQuery, IList<PartsViewModel>>
    {

        private readonly IAsyncRepository<Part> _partRepository;
        private readonly IMapper _mapper;

        public GetPartsListQueryHandler(IMapper mapper, IAsyncRepository<Part> partRepository)
        {
            _mapper = mapper;
            _partRepository = partRepository;
        }

        public async Task<IList<PartsViewModel>> Handle(GetPartsListQuery request, CancellationToken cancellationToken)
        {
            var allParts = (await _partRepository.ListAllAsync()).OrderBy(x => x.PartNum);
            return _mapper.Map<List<PartsViewModel>>(allParts);
        }

    }
}