namespace NetLab1.Domain.Models;

public class MonthlyPayment
{
    public long Id { get; set; }
    
    public long EmploymentId { get; set; }
    
    public decimal Size { get; set; }
    
    public DateTimeOffset Date { get; set; }
}