namespace Api.Dtos.Paycheck;

public record Paycheck
{
    public decimal GrossPay { get; init; }
    public decimal BenefitsDeduction { get; init; }
    public decimal NetPay { get; init; }
}
