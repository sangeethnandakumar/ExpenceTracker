using LanguageExt.Common;
using MediatR;

namespace Application.Entries.Commands.Create
{
    public sealed record CreateEntryCommand(
            float amount,
            string currencycode
        ) : IRequest<Result<Guid>>;
}
