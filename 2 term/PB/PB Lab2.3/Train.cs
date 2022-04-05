using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB_Lab2._3
{
    public class Train
    {
        private TimeOnly departureTime;
        public int Number { get; set; }
        public string Destination { get; set; }
        public string DepartureTime
        {
            get
            {
                return $"{departureTime.Hour}-{departureTime.Minute}";
            }
            set
            {
                if (value[2] == '-' && int.TryParse(value.Substring(0, 2), out int hours) && int.TryParse(value.Substring(3, 2), out int minutes))
                {
                    departureTime = new TimeOnly(hours, minutes); 
                }
                else
                {
                    throw new ArgumentException("Wrong format of time");
                }
            }
        }
        public TimeOnly GetDepartureTime() => departureTime;
        private Train(int number, string destination)
        {
            this.Number = number;
            this.Destination = destination;
        }
        public Train(int number, string destination, TimeOnly departureTime): this(number, destination)
        {
            this.departureTime = departureTime;
        }
        public Train(int number, string destination, string departureTime) : this(number, destination)
        {
            this.DepartureTime = departureTime;
        }
    }
}
