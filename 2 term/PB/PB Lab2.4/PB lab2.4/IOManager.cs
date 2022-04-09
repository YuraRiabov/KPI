using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB_lab2._4
{
    public class IOManager
    {
        public void OutputTime(string name, Time time)
        {
            Console.WriteLine("{0} is {1:d2}:{2:d2}:{3:d2}", name, time.Hours, time.Minutes, time.Seconds);
        }
        public void CompareTimes(Time time1, Time time2, string time1Name, string time2Name)
        {
            if (time1 > time2)
            {
                Console.WriteLine($"{time1Name} is bigger");
            }
            else
            {
                Console.WriteLine($"{time2Name} is bigger");
            }
        }

        public Time GetTime()
        {
            Time time;
            int hours;
            int minutes;
            int seconds;
            Console.WriteLine("Enter hours:");
            while(!int.TryParse(Console.ReadLine(), out hours))
            {
                Console.WriteLine("Invalid input, try again");
            }
            Console.WriteLine("Enter minutes:");
            while (!int.TryParse(Console.ReadLine(), out minutes))
            {
                Console.WriteLine("Invalid input, try again");
            }
            Console.WriteLine("Enter seconds:");
            while (!int.TryParse(Console.ReadLine(), out seconds))
            {
                Console.WriteLine("Invalid input, try again");
            }
            time = new Time(hours, minutes, seconds);
            return time;
        }
    }
}
