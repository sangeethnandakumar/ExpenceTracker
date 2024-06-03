using NMoneys;

namespace Domain.ValueTypes
{
    public record Amount(double amount, Currency currency);
}
