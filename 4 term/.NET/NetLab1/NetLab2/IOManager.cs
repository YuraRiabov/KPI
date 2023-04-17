using NetLab1.Domain.Models;

namespace NetLab2;

public class IOManager
{
    private readonly PersonService _personService;
    public IOManager(PersonService personService)
    {
        _personService = personService;
    }

    public void Process()
    {
        var escape = false;
        while (!escape)
        {
            Console.Write("Enter a number of query or 'q' to quit: ");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Get all people:");
                    OutputPeople(_personService.GetAllPeople());
                    break;
                case "2":
                    Console.WriteLine("Get people with maximum payment:");
                    OutputPeople(_personService.GetPeopleByMaxPayment());
                    break;
                case "3":
                    Console.WriteLine("Get top 3 people by average payment:");
                    OutputPeople(_personService.GetTopPeople(3));
                    break;
                case "4":
                    Console.WriteLine("Get philosophy doctors:");
                    OutputPeople(_personService.GetPhilosophyDoctors());
                    break;
                case "5":
                    Console.WriteLine("Get average payment by major:");
                    foreach (var (major, avgPayment) in _personService.GetAveragePaymentByMajor())
                    {
                        Console.WriteLine($"{major}: {avgPayment}");
                    }
                    break;
                case "6":
                    Console.WriteLine("Get people with first name starting with r:");
                    OutputPeople(_personService.GetStartingWithLetter('r'));
                    break;
                case "7":
                    Console.WriteLine("Get count of people with education level higher than Bachelor:");
                    int higherThanBachelorCount = _personService.GetWithHigherThanBachelorCount();
                    Console.WriteLine($"Number of people with education level higher than Bachelor: {higherThanBachelorCount}");
                    break;
                case "8":
                    Console.WriteLine("Get person with longest employment:");
                    Console.WriteLine(_personService.GetLongestWorking());
                    break;
                case "9":
                    Console.WriteLine("Get youngest person:");
                    Console.WriteLine(_personService.GetYoungest());
                    break;
                case "10":
                    Console.WriteLine("Get oldest person with payment above average:");
                    Console.WriteLine(_personService.GetOldestAboveAverage());
                    break;
                case "11":
                    Console.WriteLine("Get average age of people:");
                    double averageAge = _personService.GetAverageAge();
                    Console.WriteLine($"Average age of people: {averageAge}");
                    break;
                case "12":
                    Console.WriteLine("Get person with oldest taxpayer card:");
                    Console.WriteLine(_personService.GetWithOldestCard());
                    break;
                case "13":
                    Console.WriteLine("Get age amplitude:");
                    TimeSpan ageAmplitude = _personService.GetAgeAmplitude();
                    Console.WriteLine($"Age amplitude: {ageAmplitude.Days / 365.0}");
                    break;
                case "14":
                    Console.WriteLine("Get maximum difference in average payments:");
                    decimal maxPaymentDifference = _personService.GetMaxAveragePaymentDifference();
                    Console.WriteLine($"Maximum difference in average payments: {maxPaymentDifference}");
                    break;
                case "15":
                    Console.WriteLine("Get person with lowest personnel number:");
                    Console.WriteLine(_personService.GetWithLowestPersonnelNumber());
                    break;
                case "q":
                    escape = true;
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
            Console.WriteLine();
        }
    }

    private void OutputPeople(IEnumerable<Person> persons)
    {
        foreach (var person in persons)
        {
            Console.WriteLine(person);
        }
    }
}