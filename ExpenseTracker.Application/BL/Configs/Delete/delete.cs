using LanguageExt.Common;
using MediatR;

namespace Application.BL.Configs.Delete
{
    public sealed record DeleteConfigCommand(string Id) : IRequest<Result<string>>;
}
