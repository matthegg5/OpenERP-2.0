using MediatR;
using OpenERP.Application.Contracts.Persistence;
using AutoMapper;
using OpenERP.Domain.Entities;
using OpenERP.Application.ViewModels;

namespace OpenERP.Application.Features.Parts.Commands.DeletePart
{
    public class DeletePartCommandHandler : IRequestHandler<DeletePartCommand>
    {
        private readonly IAsyncRepository<Part> _partRepository;
        private readonly IMapper _mapper;

        public DeletePartCommandHandler(IMapper mapper, IAsyncRepository<Part> partRepository)
        {
            _mapper = mapper;
            _partRepository = partRepository;
        }

        public async Task Handle(DeletePartCommand request, CancellationToken cancellationToken)
        {
            var partToDelete = await _partRepository.GetByIdAsync(request.PartId);
            await _partRepository.DeleteAsync(partToDelete);
        }
    }
}