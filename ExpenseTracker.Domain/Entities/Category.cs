using Domain.Primitives;

namespace Domain.Entities
{

    public sealed class Category : Entity
    {
        //Private Contructor for EFCore
        private Category() { }

        //Contructor
        public Category(string title, string text, string icon, string color, string customImage) : base(Guid.NewGuid())
        {
            Title = title;
            Text = text;
            Icon = icon;
            Color = color;
            CustomImage = customImage;
        }

        //Immutable Props
        public string Title { get; private set; }
        public string Text { get; private set; }
        public string? Icon { get; private set; }
        public string Color { get; private set; }
        public string? CustomImage { get; set; }
    }
}
