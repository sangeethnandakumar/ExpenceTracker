using FluentValidation;

namespace Application.BL.Configs.GetById
{
    public sealed class GetConfigQueryValidator : AbstractValidator<GetConfigQuery>
    {
        public GetConfigQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Is required.")
                .Must(id => Guid.TryParse(id, out _)).WithMessage("Must be a valid GUID.");
        }
    }
}
