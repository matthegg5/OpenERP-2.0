using MediatR;
using OpenERP.Application.Contracts.Persistence;
using AutoMapper;
using OpenERP.Domain.Entities;
using OpenERP.Application.ViewModels;

namespace OpenERP.Application.Features.Parts.Queries.GetPartRevisionsList
{
    public class GetPartRevisionsListQueryHandler : IRequestHandler<GetPartRevisionsListQuery, PartRevisionsViewModel>
    {

        private readonly IAsyncRepository<PartRevision> _partRevisionRepository;
        private readonly IAsyncRepository<Part> _partRepository;
        private readonly IMapper _mapper;

        public GetPartRevisionsListQueryHandler(IMapper mapper, IAsyncRepository<PartRevision> partRevisionRepository, IAsyncRepository<Part> partRepository)
        {
            _mapper = mapper;
            _partRevisionRepository = partRevisionRepository;
            _partRepository = partRepository;
        }

        public async Task<PartRevisionsViewModel> Handle(GetPartRevisionsListQuery request, CancellationToken cancellationToken)
        {
            var part = await _partRepository.GetByIdAsync(request.PartId);
            var partRevisionDto = _mapper.Map<PartRevisionsViewModel>(part);

            partRevisionDto.Part = _mapper.Map<PartsViewModel>(part);
            return partRevisionDto;
        }

    }
}