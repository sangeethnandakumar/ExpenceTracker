using Domain.Enums;

namespace Presentation.Models
{
    public record CreateUserRequest(
       string FirstName,
       string LastName,
       string Email,
       LogInMode LogInMode,
       DateOnly? DateOfBirth,
       Gender Gender,
       string Country,
       string Password
   );

}
