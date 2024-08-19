using FluentValidation;

namespace Application.BL.Configs.Delete
{
    public sealed class DeleteConfigQueryValidator : AbstractValidator<DeleteConfigCommand>
    {
        public DeleteConfigQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Is required.")
                .Must(id => Guid.TryParse(id, out _)).WithMessage("Must be a valid GUID.");
        }
    }
}
