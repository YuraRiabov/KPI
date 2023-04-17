using Bogus;
using NetLab1.Domain.Models;
using NetLab1.Domain.Models.Enums;
using Person = NetLab1.Domain.Models.Person;

namespace NetLab1.Infrastructure;

public static class DataGenerator
{
    private const int PersonCount = 100;
    private const int MonthCount = 12;
    private const int Seed = 73;
    public static DataContext Generate()
    {
        var context = new DataContext
        {
            Educations = GenerateEducations(),
            Persons = GeneratePeople(),
            TaxpayerCards = GenerateTaxpayerCards(),
            Employments = GenerateEmployments(),
            MonthlyPayments = GenerateMonthlyPayments()
        };
        
        PopulateContext(context);

        return context;
    }

    private static List<Education> GenerateEducations()
    {
        var educations = new List<Education>();
        var id = 1;
        var personId = 1;
        var bachelors = new Faker<Education>()
            .UseSeed(Seed)
            .RuleFor(e => e.Id, _ => id++)
            .RuleFor(e => e.Start, f => f.Date.Past(10))
            .RuleFor(e => e.End, f => f.Date.Past(5))
            .RuleFor(e => e.Major, f => (Major)f.Random.Int(0, 2))
            .RuleFor(e => e.Degree, _ => Degree.Bachelor)
            .RuleFor(e => e.PersonId, _ => personId++)
            .Generate(PersonCount);
        educations.AddRange(bachelors);
        
        personId = 1;
        var masters = new Faker<Education>()
            .UseSeed(Seed)
            .RuleFor(e => e.Id, _ => id++)
            .RuleFor(e => e.Start, f => f.Date.Past(5))
            .RuleFor(e => e.End, f => f.Date.Past(3))
            .RuleFor(e => e.Major, f => (Major)f.Random.Int(0, 2))
            .RuleFor(e => e.Degree, _ => Degree.Master)
            .RuleFor(e => e.PersonId, _ => personId++)
            .Generate(PersonCount / 2);
        educations.AddRange(masters);
        
        personId = 1;
        var philosophyDoctors = new Faker<Education>()
            .UseSeed(Seed)
            .RuleFor(e => e.Id, _ => id++)
            .RuleFor(e => e.Start, f => f.Date.PastOffset(3))
            .RuleFor(e => e.End, f => f.Date.PastOffset(1))
            .RuleFor(e => e.Major, f => (Major)f.Random.Int(0, 2))
            .RuleFor(e => e.Degree, _ => Degree.PhD)
            .RuleFor(e => e.PersonId, _ => personId++)
            .Generate(PersonCount / 4);
        educations.AddRange(philosophyDoctors);

        return educations;
    }

    private static List<Person> GeneratePeople()
    {
        var id = 1;
        return new Faker<Person>()
            .UseSeed(Seed)
            .RuleFor(p => p.Id, _ => id++)
            .RuleFor(p => p.BirthDate, f => f.Date.PastOffset(10, new DateTime(2005, 1, 1)))
            .RuleFor(p => p.FirstName, f => f.Person.FirstName)
            .RuleFor(p => p.LastName, f => f.Person.LastName)
            .RuleFor(p => p.MiddleName, f => f.Person.FirstName)
            .RuleFor(p => p.PersonnelNumber, f => f.Random.Int(100000, 999999))
            .Generate(PersonCount);
    }

    private static List<TaxpayerCard> GenerateTaxpayerCards()
    {
        var id = 1;
        var personId = 1;
        return new Faker<TaxpayerCard>()
            .UseSeed(Seed)
            .RuleFor(c => c.Id, _ => id++)
            .RuleFor(c => c.PersonId, _ => personId++)
            .RuleFor(c => c.IssuedAt, f => f.Date.Past(3))
            .Generate(PersonCount);
    }

    private static List<Employment> GenerateEmployments()
    {
        var id = 1;
        var taxpayerCardId = 1;
        return new Faker<Employment>()
            .UseSeed(Seed)
            .RuleFor(e => e.Id, _ => id++)
            .RuleFor(e => e.TaxpayerCardId, _ => taxpayerCardId++)
            .RuleFor(e => e.StartedAt, f => f.Date.Past())
            .RuleFor(e => e.LeftAt, _ => null)
            .Generate(PersonCount);
    }

    private static List<MonthlyPayment> GenerateMonthlyPayments()
    {
        var id = 1;
        var employmentId = 0;
        var monthNumber = 0;
        return new Faker<MonthlyPayment>()
            .UseSeed(Seed)
            .RuleFor(p => p.Id, _ => id++)
            .RuleFor(p => p.EmploymentId, _ => employmentId++ % PersonCount + 1)
            .RuleFor(p => p.Date, f => f.Date.Recent(30 * (monthNumber++ % MonthCount)))
            .RuleFor(p => p.Size, f => 5000 * f.Random.Decimal(0.6M))
            .Generate(PersonCount * MonthCount);
    }

    private static void PopulateContext(DataContext context)
    {
        foreach (var employment in context.Employments)
        {
            employment.Payments = context.MonthlyPayments.Where(p => p.EmploymentId == employment.Id).ToList();
        }

        foreach (var taxpayerCard in context.TaxpayerCards)
        {
            taxpayerCard.Employment = context.Employments.First(e => e.TaxpayerCardId == taxpayerCard.Id);
        }

        foreach (var person in context.Persons)
        {
            person.Educations = context.Educations.Where(e => e.PersonId == person.Id).ToList();
            person.TaxpayerCard = context.TaxpayerCards.First(c => c.PersonId == person.Id);
        }
    }
}