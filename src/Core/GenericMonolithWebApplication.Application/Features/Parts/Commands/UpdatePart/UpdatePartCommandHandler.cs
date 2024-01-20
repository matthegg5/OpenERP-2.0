using MediatR;
using GenericMonolithWebApplication.Application.Contracts.Persistence;
using AutoMapper;
using GenericMonolithWebApplication.Domain.Entities;
using GenericMonolithWebApplication.Application.ViewModels;

namespace GenericMonolithWebApplication.Application.Features.Parts.Commands.UpdatePart
{
    public class UpdatePartCommandHandler : IRequestHandler<UpdatePartCommand>
    {
        private readonly IAsyncRepository<Part> _partRepository;
        private readonly IMapper _mapper;

        public UpdatePartCommandHandler(IMapper mapper, IAsyncRepository<Part> partRepository)
        {
            _mapper = mapper;
            _partRepository = partRepository;
        }

        public async Task Handle(UpdatePartCommand request, CancellationToken cancellationToken)
        {
            var partToUpdate = await _partRepository.GetByIdAsync(request.PartId);
            _mapper.Map(request, partToUpdate, typeof(UpdatePartCommand), typeof(Part));
            await _partRepository.UpdateAsync(partToUpdate);

        }
    }
    
}