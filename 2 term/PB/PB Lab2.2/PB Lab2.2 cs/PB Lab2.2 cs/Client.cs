using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB_Lab2._2_cs
{
    public struct Client
    {
        public static TimeOnly WorkStartTime { get; } = new TimeOnly(9, 0);
        public static TimeOnly WorkEndTime { get; } = new TimeOnly(17, 0);
        public string Name { get; set; }
        public TimeOnly ComingTime { get; set; }
        public TimeOnly LeavingTime { get; set; }
        public Client(string name, TimeOnly comingTime, TimeOnly leavingTime)
        {
            Name = name;
            ComingTime = comingTime;
            LeavingTime = leavingTime;
        }
    }
}
