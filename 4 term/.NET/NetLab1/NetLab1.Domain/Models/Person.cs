namespace NetLab1.Domain.Models;

public class Person
{
    public long Id { get; set; }

    public string FirstName { get; set; }

    public string MiddleName { get; set; }

    public string LastName { get; set; }
    
    public DateTimeOffset BirthDate { get; set; }

    public long PersonnelNumber { get; set; }

    public TaxpayerCard TaxpayerCard { get; set; } = new();

    public List<Education> Educations { get; set; } = new();

    public override string ToString()
    {
        return FirstName + ' ' + MiddleName + ' ' + LastName;
    }
}