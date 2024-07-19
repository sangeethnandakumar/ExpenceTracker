using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Category : Entity
    {
        //Private Contructor for EFCore
        private Category() { }

        //Contructor
        public Category(string title, string text, Guid? sub, string icon) : base(Guid.NewGuid())
        {
            Title = title;
            Text = text;
            Sub = sub;
            Icon = icon;
        }

        //Immutable Props
        public string Title { get; private set; }
        public string Text { get; private set; }
        public Guid? Sub { get; private set; }
        public string Icon { get; private set; }
    }
}
