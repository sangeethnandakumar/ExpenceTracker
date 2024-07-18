using Application.Dtos;
using LanguageExt.Common;
using MediatR;

namespace Application.BL.Categories.GetById
{
    public sealed record GetCategoryQuery(string Id) : IRequest<Result<CategoryDto>>;
}
