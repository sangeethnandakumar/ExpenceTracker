using FluentValidation;

namespace Application.BL.Tracks.GetAll
{
    public sealed class GetTracksQueryValidator : AbstractValidator<GetTracksQuery>
    {
        public GetTracksQueryValidator()
        {
        }
    }
}
