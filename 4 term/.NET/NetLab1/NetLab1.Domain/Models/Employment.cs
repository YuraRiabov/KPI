namespace NetLab1.Domain.Models;

public class Employment
{
    public long Id { get; set; }
    
    public long TaxpayerCardId { get; set; }
    
    public DateTimeOffset StartedAt { get; set; }
    
    public DateTimeOffset? LeftAt { get; set; }

    public List<MonthlyPayment> Payments { get; set; } = new();
}