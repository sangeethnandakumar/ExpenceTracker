using Domain.Enums;
using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Config : Entity
    {
        public Config(Guid accountId, string preferedCurrency, List<Platforms> platformsUsed, string appVersion, LogInMode loginMode, Dictionary<string, Dictionary<string, string>> clusters)
        {
            AccountId = accountId;
            PreferedCurrency = preferedCurrency;
            PlatformsUsed = platformsUsed;
            AppVersion = appVersion;
            LoginMode = loginMode;
            Clusters = clusters;
        }

        private Config() { }

        public Guid AccountId { get; private set; }
        public string PreferedCurrency { get; private set; }
        public List<Platforms> PlatformsUsed { get; private set; }
        public string AppVersion { get; private set; }
        public LogInMode LoginMode { get; private set; }
        public Dictionary<string, Dictionary<string, string>> Clusters { get; private set; }
    }
}
