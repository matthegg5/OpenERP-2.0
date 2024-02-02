using MediatR;
using FluentValidation;
using GenericMonolithWebApplication.Application.Contracts.Persistence;

#nullable disable

namespace GenericMonolithWebApplication.Application.Features.Parts.Commands.CreatePart
{
    public class CreatePartCommand : IRequest<Guid>
    {
        public string PartNum { get; set;}
        public string PartDescription { get; set;}
        public override string ToString()
        {
            return $"Part: {PartNum}, Descrption: {PartDescription}";
        }
    }

    public class Validation : AbstractValidator<CreatePartCommand>
    {
	private readonly IPartRepository _partRepository;
	
	public Validation(IPartRepository partRepository)
	{
	    _partRepository = partRepository;

	    RuleFor(p => p)
		.MustAsync(PartNumUnique).WithMessage("Part number {PropertyValue} already exists.");
	    
	    RuleFor(x => x.PartNum)
		.NotEmpty().WithMessage("{PropertyName} is required.")
		.NotNull()
		.MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
	    RuleFor(x => x.PartDescription)
		.NotEmpty().WithMessage("{PropertyName} is required.")
		.NotNull()
		.MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.");
	}

	private async Task<bool> PartNumUnique(CreatePartCommand request, CancellationToken cancellationToken)
	{
	    return !(await _partRepository.IsPartNumUnique(request.PartNum));
	}
    }
}
