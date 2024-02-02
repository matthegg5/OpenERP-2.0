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

	    // this is ok for now but can try to implement BaseHandler such that it uses Reflection to validate without being called explicitly
	    // var validator = new Validation(_partRepository);
	    // var validationResult = await validator.ValidateAsync(request);

	    // if (validationResult.Errors.Count > 0)
		// throw new Exceptions.ValidationException(validationResult);
	    
            @part = await _partRepository.AddAsync(@part);
            return @part.PartId;
        }
    }
} 
