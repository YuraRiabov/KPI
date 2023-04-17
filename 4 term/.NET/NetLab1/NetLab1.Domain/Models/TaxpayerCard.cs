namespace NetLab1.Domain.Models;

public class TaxpayerCard
{
    public long Id { get; set; }
    
    public long PersonId { get; set; }
    
    public DateTimeOffset IssuedAt { get; set; }

    public Employment Employment { get; set; }
}