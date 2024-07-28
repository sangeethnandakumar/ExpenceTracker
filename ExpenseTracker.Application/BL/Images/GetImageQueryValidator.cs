using FluentValidation;

namespace Application.BL.Images
{
    public sealed class GetImageQueryValidator : AbstractValidator<GetImageQuery>
    {
        public GetImageQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Is required.")
                .Must(id => Guid.TryParse(id, out _)).WithMessage("Must be a valid GUID.");
        }
    }
}
