using Domain.Entities;
using LanguageExt.Common;

namespace Domain.Abstractions
{
    public interface IEntryRepository
    {
        Result<IEnumerable<Entry>> GetUserEntries(Guid userId);
        Result<Entry> GetEntry(Guid id);
        Result<Guid> CreateEntry(Entry entry);
        Result<Guid> UpdateEntry(Entry entry);
        Result<Guid> DeleteEntry(Guid id);
    }
}
