using Domain.Enums;
using Domain.ValueObjects;
using LanguageExt.Common;
using MediatR;

namespace Application.Entries.Commands.Create
{
    public sealed record CreateEntryCommand(
            Amount Amount,
            string Note,
            Guid? CatageoryId,
            EntryKind Kind,
            Guid AccountId
        ) : IRequest<Result<Guid>>;
}
