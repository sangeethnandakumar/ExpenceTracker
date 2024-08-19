using LanguageExt.Common;
using MediatR;

namespace Application.BL.Configs.Create
{
    public sealed record CreateConfigCommand() : IRequest<Result<string>>;
}
