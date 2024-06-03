using Domain.Abstractions;
using Domain.Entities;
using LanguageExt.Common;

namespace Infrastructure.Repositories
{
    public sealed class EntryRepository : IEntryRepository
    {
        public Result<Guid> CreateEntry(Entry entry)
        {
            return new Result<Guid>();
        }

        public Result<Guid> DeleteEntry(Guid id)
        {
            return new Result<Guid>();
        }

        public Result<Entry> GetEntry(Guid id)
        {
            return new Result<Entry>();
        }

        public Result<IEnumerable<Entry>> GetUserEntries(Guid userId)
        {
            return new Result<IEnumerable<Entry>>();
        }

        public Result<Guid> UpdateEntry(Entry entry)
        {
            return new Result<Guid>();
        }
    }
}
