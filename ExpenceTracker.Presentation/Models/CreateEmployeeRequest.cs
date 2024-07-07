namespace Presentation.Models
{
    public sealed record CreateEmployeeRequest(
          string Name,
          bool IsDeveloper,
          int Age,
          string Dob
    );
}
