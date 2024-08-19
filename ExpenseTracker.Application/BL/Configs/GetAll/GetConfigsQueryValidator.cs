using FluentValidation;

namespace Application.BL.Configs.GetAll
{
    public sealed class GetConfigsQueryValidator : AbstractValidator<GetConfigsQuery>
    {
        public GetConfigsQueryValidator()
        {
        }
    }
}
