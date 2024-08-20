using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class DeveloperSuggestion : Entity
    {
        //Private Contructor for EFCore
        private DeveloperSuggestion() { }

        //Contructor
        public DeveloperSuggestion(string userId, string appName, string message) : base(Guid.NewGuid())
        {
            UserId = userId;
            AppName = appName;
            Message = message;
        }

        //Immutable Props
        public string UserId { get; private set; }
        public string AppName { get; private set; }
        public string Message { get; private set; }
    }
}
