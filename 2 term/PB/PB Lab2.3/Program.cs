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
            IOManager iOManager = new IOManager();
            List<Train> trains;
            Console.WriteLine(@"Enter trains in format: number destination hh-mm(departure time). To stop inputing press Enter twice");
            trains = iOManager.GetTrains();
            Console.Write("Enter destination to see the last train to depart there:");
            string? destination = Console.ReadLine();
            try
            {
                int lastNumber = iOManager.LastToDepart(destination, trains);
                Console.WriteLine("The number of this train is {0}", lastNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}