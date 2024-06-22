using Domain.Enums;

namespace Domain.ValueObjects
{
    public record Credential(LogInMode loginMode, string Email, string Password);
}
