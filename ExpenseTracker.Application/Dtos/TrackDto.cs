namespace Application.Dtos
{
    public sealed record TrackDto(
          Guid Id,
          DateTime Date,
          int Exp,
          int Inc,
          string Notes,
          Guid Category
    );
}
