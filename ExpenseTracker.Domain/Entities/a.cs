using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class DeveloperSuggession : Entity
    {
        //Private Contructor for EFCore
        private DeveloperSuggession() { }

        //Contructor
        public DeveloperSuggession(string userId, string appName, string message) : base(Guid.NewGuid())
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
