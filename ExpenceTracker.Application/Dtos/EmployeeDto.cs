namespace Application.Dtos
{
    public sealed record EmployeeDto(
         Guid Id,
         string Name,
         bool IsDeveloper,
         int Age,
         string Dob
   );
}
