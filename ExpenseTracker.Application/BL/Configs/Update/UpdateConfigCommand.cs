using LanguageExt.Common;
using MediatR;

namespace Application.BL.Configs.Update
{
    public sealed record UpdateConfigCommand() : IRequest<Result<string>>
    {
        public string? Id { get; set; }
        public string? Instance { get; set; }
        public bool IsFirstRun { get; set; }
        public bool ShowTour { get; set; }
        public bool RequiresNotesForTracks { get; set; }
        public string? DeviceId { get; set; }
        public User? User { get; set; }
        public Sync? Sync { get; set; }
        public Update? Update { get; set; }
        public Rating? Rating { get; set; }
        public Subscription? Subscription { get; set; }
        public List<Device>? Devices { get; set; }
        public List<Misc>? Misc { get; set; }
    }

    public sealed record User
    {
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Image { get; set; }
        public string? Timezone { get; set; }
        public string? Country { get; set; }
        public string? Currency { get; set; }
    }

    public sealed record Sync
    {
        public string LastConfigSync { get; set; }
        public string LastCategorySync { get; set; }
        public string LastRecordsSync { get; set; }
    }

    public sealed record Update
    {
        public bool ForceUpdate { get; set; }
        public double Latest { get; set; }
        public string Title { get; set; }
        public string Changelog { get; set; }
    }

    public sealed record Rating
    {
        public bool ForcePrompt { get; set; }
        public bool CompletedRating { get; set; }
    }

    public sealed record Subscription
    {
        public bool IsSubscribed { get; set; }
        public string? SubscriptionPlan { get; set; }
    }

    public sealed record Device
    {
        public string? Id { get; set; }
        public string? Model { get; set; }
        public string? Brand { get; set; }
        public string? Manufacturer { get; set; }
        public string? Board { get; set; }
        public string? Product { get; set; }
        public string? DeviceName { get; set; }
        public string? VersionRelease { get; set; }
        public string? VersionIncremental { get; set; }
        public string? VersionBaseOS { get; set; }
    }

    public sealed record Misc
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
