using MediatR;
using GenericMonolithWebApplication.Application.Contracts.Persistence;
using AutoMapper;
using GenericMonolithWebApplication.Domain.Entities;
using GenericMonolithWebApplication.Application.ViewModels;

namespace GenericMonolithWebApplication.Application.Features.Parts.Commands.DeletePart
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