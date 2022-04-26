using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB_lab2._4
{
    class Program
    {
        static void Main()
        {
            IOManager iOManager = new IOManager();
            string firstTimeName = "T1";
            string secondTimeName = "T2";
            string thirdTimeName = "T3";
            Random random = new Random();
            Time firstTime = new Time(random.Next(0, 24));
            Time secondTime = new Time(random.Next(0, 24), random.Next(0, 60));
            Time thirdTime = new Time(random.Next(0, 24), random.Next(0, 60), random.Next(0, 60));
            iOManager.OutputTime(firstTimeName, firstTime);
            iOManager.OutputTime(secondTimeName, secondTime);
            iOManager.OutputTime(thirdTimeName, thirdTime);
            firstTime = +firstTime;
            secondTime++;
            Console.WriteLine("After increment:");
            iOManager.OutputTime(firstTimeName, firstTime);
            iOManager.OutputTime(secondTimeName, secondTime);
            iOManager.CompareTimes(firstTime, secondTime, firstTimeName, secondTimeName);
            Console.WriteLine($"Enter time to see number of seconds from {thirdTimeName} to it");
            Time timeToCompare = iOManager.GetTime();
            int difference = thirdTime.TimeToMoment(timeToCompare);
            Console.WriteLine($"Difference is {difference}");
        }
    }
}