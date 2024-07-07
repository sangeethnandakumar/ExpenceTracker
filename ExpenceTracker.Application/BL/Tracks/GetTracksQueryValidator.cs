using FluentValidation;

namespace Application.BL.Tracks
{
    public sealed class GetTracksQueryValidator : AbstractValidator<GetTracksQuery>
    {
        public GetTracksQueryValidator()
        {
        }
    }
}
