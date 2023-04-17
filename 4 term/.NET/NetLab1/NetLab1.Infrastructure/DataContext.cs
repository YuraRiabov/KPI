using NetLab1.Domain.Models;

namespace NetLab1.Infrastructure;

public class DataContext
{
    public List<Person> Persons { get; set; } = new();
    public List<TaxpayerCard> TaxpayerCards { get; set; } = new();
    public List<Employment> Employments { get; set; } = new();
    public List<MonthlyPayment> MonthlyPayments { get; set; } = new();
    public List<Education> Educations { get; set; } = new();
}