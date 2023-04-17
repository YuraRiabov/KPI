using NetLab1.Domain.Models;
using NetLab1.Domain.Models.Enums;
using NetLab1.Infrastructure;

namespace NetLab1;

public class PersonService
{
    private readonly DataContext _context;
    public PersonService(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<Person> GetAllPeople() //1
    {
        return from person in _context.Persons select person;
    }

    public IEnumerable<Person> GetPeopleByMaxPayment() //2
    {
        return _context.Persons.OrderBy(p => p.TaxpayerCard.Employment.Payments.Max(payment => payment.Size));
    }

    public IEnumerable<Person> GetTopPeople(int count) //3
    {
        return _context.Persons
            .OrderByDescending(p => p.TaxpayerCard.Employment.Payments.Average(payment => payment.Size))
            .Take(count);
    }

    public IEnumerable<Person> GetPhilosophyDoctors() //4
    {
        return _context.Persons.Where(p => p.Educations.Any(e => e.Degree == Degree.PhD));
    }

    public IEnumerable<(Major, decimal)> GetAveragePaymentByMajor() //5
    {
        return _context.Persons
            .GroupBy(p => p.Educations.First(e => e.Degree == Degree.Bachelor).Major)
            .Select(g => (g.Key, g.Average(p => p.TaxpayerCard.Employment.Payments.Average(mp => mp.Size))));
    }

    public IEnumerable<Person> GetStartingWithLetter(char letter) //6
    {
        return _context.Persons.Where(p => p.FirstName.ToLower().StartsWith(letter));
    }

    public int GetWithHigherThanBachelorCount() //7
    {
        return _context.Persons.Count(p => p.Educations.Any(e => e.Degree != Degree.Bachelor));
    }

    public Person GetLongestWorking() //8
    {
        return _context.Persons.MinBy(p => p.TaxpayerCard.Employment.StartedAt)!;
    }

    public Person GetYoungest() //9
    {
        return _context.Persons.OrderByDescending(p => p.BirthDate).First();
    }

    public Person GetOldestAboveAverage() //10
    {
        return _context.Persons
            .Where(p =>
                p.TaxpayerCard.Employment.Payments.Average(mp => mp.Size) >
                _context.MonthlyPayments.Average(mp => mp.Size))
            .OrderBy(p => p.BirthDate).First();
    }

    public double GetAverageAge() //11
    {
        return _context.Persons
            .Select(p => DateTimeOffset.Now.Year - p.BirthDate.Year)
            .Average();
    }

    public Person GetWithOldestCard() //12
    {
        return _context.Persons.MaxBy(p => p.TaxpayerCard.IssuedAt)!;
    }

    public TimeSpan GetAgeAmplitude() //13
    {
        return _context.Persons.Max(p => p.BirthDate) - _context.Persons.Min(p => p.BirthDate);
    }

    public decimal GetMaxAveragePaymentDifference() //14
    {
        return _context.MonthlyPayments.Max(p => p.Size) - _context.MonthlyPayments.Min(p => p.Size);
    }

    public Person GetWithLowestPersonnelNumber() // 15
    {
        return _context.Persons.MinBy(p => p.PersonnelNumber)!;
    }

    public IEnumerable<(Person, decimal)> GetPeopleMinPayment() //16
    {
        return _context.Persons
            .GroupJoin(_context.MonthlyPayments,
                p => p.TaxpayerCard.Employment.Id,
                mp => mp.EmploymentId,
                (p, mp) => (p, mp.Min(payment => payment.Size)));
    }

    public double GetAverageDegreeNumber() //17
    {
        return _context.Persons.Average(p => p.Educations.Count);
    }

    public IEnumerable<(Person, int)> GetPeoplePaymentCount() //18
    {
        return _context.Persons
            .Select(p => (p, p.TaxpayerCard.Employment.Payments.Count));
    }

    public decimal GetAveragePhilosophyDoctorPayment() //19
    {
        return _context.Persons
            .Where(p => p.Educations.Any(e => e.Degree == Degree.PhD))
            .SelectMany(p => p.TaxpayerCard.Employment.Payments)
            .Average(p => p.Size);
    }

    public IEnumerable<Person> GetPeopleByMaxPaymentAndGraduation() //20
    {
        return _context.Persons
            .OrderByDescending(p => p.TaxpayerCard.Employment.Payments.Max(mp => mp.Size))
            .ThenBy(p => p.Educations.MaxBy(e => e.End)!.End);
    }
}