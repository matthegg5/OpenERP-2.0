using MediatR;
using GenericMonolithWebApplication.Application.Contracts.Persistence;
using AutoMapper;
using GenericMonolithWebApplication.Domain.Entities;
using GenericMonolithWebApplication.Application.ViewModels;

namespace GenericMonolithWebApplication.Application.Features.Parts.Commands.CreatePart
{
    public class CreatePartCommandHandler : IRequestHandler<CreatePartCommand, Guid>
    {
        private readonly IPartRepository _partRepository;
        private readonly IMapper _mapper;

        public CreatePartCommandHandler(IMapper mapper, IPartRepository partRepository)
        {
            _mapper = mapper;
            _partRepository = partRepository;
        }

        public async Task<Guid> Handle(CreatePartCommand request, CancellationToken cancellationToken)
        {
            var @part = _mapper.Map<Part>(request);
            @part = await _partRepository.AddAsync(@part);
            return @part.PartId;
        }
    }
} 