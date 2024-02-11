namespace Api.Dtos.Paycheck;

public record GetPaycheckDto
{
    public decimal GrossPay { get; init; }
    public decimal BenefitsDeduction { get; init; }
    public decimal NetPay { get; init; }
}
