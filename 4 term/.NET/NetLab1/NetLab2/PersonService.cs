using System.Xml.Linq;
using NetLab1.Domain.Models;
using NetLab1.Infrastructure;

namespace NetLab2;

public class PersonService
{
    private readonly DataContext _context;
    private readonly XDocument _document;
    public PersonService(XDocument document)
    {
        _document = document;
    }

    public IEnumerable<Person> GetAllPeople() //1
    {
        return from person in _document.Descendants("Person") select person.Deserialize<Person>();
    }

    public IEnumerable<Person> GetPeopleByMaxPayment() //2
    {
        return _document.Descendants("Person")
            .OrderBy(p => p.Descendants("Size").Select(e => decimal.Parse(e.Value)).Max())
            .Deserialize<Person>();
    }

    public IEnumerable<Person> GetTopPeople(int count) //3
    {
        return _document.Descendants("Person")
            .OrderByDescending(p => p.Descendants("Size").Select(e => decimal.Parse(e.Value)).Average())
            .Take(count)
            .Deserialize<Person>();
    }

    public IEnumerable<Person> GetPhilosophyDoctors() //4
    {
        return _document.Descendants("Person")
            .Where(p => p.Descendants("Degree").Any(e => e.Value == "PhD"))
            .Deserialize<Person>();
    }

    public IEnumerable<(string, decimal)> GetAveragePaymentByMajor() //5
    {
        return _document.Descendants("Person")
            .GroupBy(p => p.Descendants("Education")
                .First(e => e.Element("Degree").Value == "Bachelor").Element("Major").Value)
            .Select(g => 
                (g.Key, g
                    .Average(p => p.Descendants("Size").Select(e => decimal.Parse(e.Value)).Average())));
    }

    public IEnumerable<Person> GetStartingWithLetter(char letter) //6
    {
        return _document.Descendants("Person").Where(p => p.Element("FirstName").Value.ToLower().StartsWith(letter)).Deserialize<Person>();
    }

    public int GetWithHigherThanBachelorCount() //7
    {
        return _document.Descendants("Person").Count(p => p.Descendants("Degree").Any(e => e.Value != "Bachelor"));
    }

    public Person GetLongestWorking() //8
    {
        return _document.Descendants("Person")
            .MinBy(p => DateTime.Parse(p.Descendants("StartedAt").First().Value))!
            .Deserialize<Person>();
    }

    public Person GetYoungest() //9
    {
        return _document.Descendants("Person")
            .OrderByDescending(p => DateTime.Parse(p.Element("BirthDate").Value))
            .First()
            .Deserialize<Person>();
    }

    public Person GetOldestAboveAverage() //10
    {
        return _document.Descendants("Person")
            .Where(p =>
                p.Descendants("Size").Select(e => decimal.Parse(e.Value)).Average() >
                _document.Descendants("Size").Select(e => decimal.Parse(e.Value)).Average())
            .OrderBy(p => DateTime.Parse(p.Element("BirthDate").Value))
            .First()
            .Deserialize<Person>();
    }

    public double GetAverageAge() //11
    {
        return _document.Descendants("Person")
            .Select(p => DateTimeOffset.Now.Year - DateTime.Parse(p.Element("BirthDate").Value).Year)
            .Average();
    }

    public Person GetWithOldestCard() //12
    {
        return _document.Descendants("Person")
            .MaxBy(p => DateTime.Parse(p.Descendants("IssuedAt").First().Value))!
            .Deserialize<Person>();
    }

    public TimeSpan GetAgeAmplitude() //13
    {
        return _document.Descendants("Person")
            .Max(p => DateTime.Parse(p.Element("BirthDate").Value)) 
               - _document.Descendants("Person").Min(p =>DateTime.Parse(p.Element("BirthDate").Value));
    }

    public decimal GetMaxAveragePaymentDifference() //14
    {
        return _document.Descendants("Size").Max(p => decimal.Parse(p.Value)) 
               - _document.Descendants("Size").Min(p => decimal.Parse(p.Value));
    }

    public Person GetWithLowestPersonnelNumber() // 15
    {
        return _document.Descendants("Person")
            .MinBy(p => decimal.Parse(p.Element("PersonnelNumber").Value))!
            .Deserialize<Person>();
    }
}