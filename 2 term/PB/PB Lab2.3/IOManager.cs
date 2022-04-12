using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB_Lab2._3
{
    public class IOManager
    {
        public List<Train> GetTrains()
        {
            string? input = Console.ReadLine();
            List<Train> trains = new List<Train>();
            while (input.Length != 0)
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

        public int LastToDepart(string? destination, List<Train> trains)
        {
            if (destination.Length == 0 || trains.Count == 0)
            {
                throw new Exception("No destination or no trains entered");
            }
            else
            {
                List<Train> withRightDestination = new List<Train>();
                foreach (Train train in trains)
                {
                    if (train.Destination == destination)
                    {
                        withRightDestination.Add(train);
                    }
                }
                if (withRightDestination.Count > 0)
                {
                    Train last = withRightDestination[0];
                    foreach (Train train in withRightDestination)
                    {
                        if (train.GetDepartureTime() > last.GetDepartureTime())
                        {
                            last = train;
                        }
                    }
                    return last.Number;
                }
                else
                {
                    throw new Exception("No trains with this destination");
                }
            }
        }
    }
}
