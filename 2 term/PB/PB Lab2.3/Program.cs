using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB_Lab2._3
{   
    public class Program
    {
        static void Main()
        {
            List<Train> trains = new List<Train>();
            Console.WriteLine(@"Enter trains in format: 'number' 'destination' 'hh-mm'(departure time). To stop inputing press Enter twice");
            GetTrains();
        }

        static List<Train> GetTrains()
        {
            string? input = Console.ReadLine();
            List<Train> trains = new List<Train>();
            while (input != null)
            {
                string[] train = input.Split(' ');
                try
                {
                    trains.Add(new Train(int.Parse(train[0]), train[1], train[2]));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                input = Console.ReadLine();
            }
            return trains;
        }
    }
}