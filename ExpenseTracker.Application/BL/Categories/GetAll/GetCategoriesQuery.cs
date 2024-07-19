using Application.Dtos;
using LanguageExt.Common;
using MediatR;

namespace Application.BL.Categories.GetAll
{
    public sealed record GetCategoriesQuery() : IRequest<Result<IEnumerable<CategoryDto>>>;
}
