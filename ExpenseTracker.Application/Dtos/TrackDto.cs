﻿namespace Application.Dtos
{
    public sealed record TrackDto(
          Guid Id,
          string Date,
          int Exp,
          int Inc,
          string Notes,
          Guid Category
    );
}