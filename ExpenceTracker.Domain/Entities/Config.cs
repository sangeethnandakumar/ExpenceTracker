using Domain.Enums;
using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Config : Entity
    {
        public Guid AccountId { get; private set; }
        public string PreferedCurrency { get; private set; }
        public List<Platforms> PlatformsUsed { get; private set; }
        public string AppVersion { get; private set; }
        public LogInMode LoginMode { get; private set; }
        public Dictionary<string, Dictionary<string, string>> Clusters { get; private set; }
    }
}
