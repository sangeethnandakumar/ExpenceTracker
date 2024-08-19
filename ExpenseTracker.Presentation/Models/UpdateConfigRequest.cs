namespace Presentation.Models
{
    public sealed record UpdateConfigRequest
    {
        public string? Instance { get; set; }
        public bool IsFirstRun { get; set; }
        public bool ShowTour { get; set; }
        public bool RequiresNotesForTracks { get; set; }
        public string? DeviceId { get; set; }
        public UserModel? User { get; set; }
        public SyncModel? Sync { get; set; }
        public UpdateModel? Update { get; set; }
        public RatingModel? Rating { get; set; }
        public SubscriptionModel? Subscription { get; set; }
        public List<DeviceModel>? Devices { get; set; }
        public List<MiscModel>? Misc { get; set; }
    }

    public sealed record UserModel
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

    public sealed record SyncModel
    {
        public string LastConfigSync { get; set; }
        public string LastCategorySync { get; set; }
        public string LastRecordsSync { get; set; }
    }

    public sealed record UpdateModel
    {
        public bool ForceUpdate { get; set; }
        public double Latest { get; set; }
        public string Title { get; set; }
        public string Changelog { get; set; }
    }

    public sealed record RatingModel
    {
        public bool ForcePrompt { get; set; }
        public bool CompletedRating { get; set; }
    }

    public sealed record SubscriptionModel
    {
        public bool IsSubscribed { get; set; }
        public string? SubscriptionPlan { get; set; }
    }

    public sealed record DeviceModel
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


    public sealed record MiscModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
