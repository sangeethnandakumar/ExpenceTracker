using LanguageExt.Common;
using MediatR;

namespace Application.Entries.Commands.CreateEntry
{
    public sealed record CreateEntryCommand(
            float amount,
            string currencycode
        ) : IRequest<Result<Guid>>;
}
