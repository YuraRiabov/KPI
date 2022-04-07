using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB_lab2._4
{
    public class Time
    {
        const int SecondsInMinute = 60;
        const int MinutesInHour = 60;
        private int seconds;
        private int minutes;
        private int hours;
        public int Seconds
        {
            get => seconds;
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentException("Invalid seconds input");
                }
                else
                {
                    seconds = value;
                }
            }
        }
        public int Minutes
        {
            get => minutes;
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentException("Invalid minutes input");
                }
                else
                {
                    minutes = value;
                }
            }
        }
        public int Hours
        {
            get => hours;
            set
            {
                if (value < 0 || value > 23)
                {
                    throw new ArgumentException("Invalid hours input");
                }
                else
                {
                    hours = value;
                }
            }
        }
        public Time(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }
        public Time(int hours, int minutes) : this(hours, minutes, 0)
        { }
        public Time(int hours) : this(hours, 0)
        { }
        public Time() : this(0)
        { }
        public static Time operator +(Time time)
        {
            return new Time(time.Hours, time.Minutes + 1, time.Seconds);
        }
        public static Time operator ++(Time time)
        {
            return new Time(time.Hours, time.Minutes, time.Seconds + 1);
        }
        public static bool operator >(Time time1, Time time2)
        {
            if (time1.Hours != time2.Hours)
            {
                return time1.Hours > time2.Hours;
            }
            else if (time1.Minutes != time2.Minutes)
            {
                return time1.Minutes > time2.Minutes;
            }
            else
            {
                return time1.Seconds > time2.Seconds;
            }
        }
        public static bool operator <(Time time1, Time time2)
        {
            if (time1.Hours != time2.Hours)
            {
                return time1.Hours < time2.Hours;
            }
            else if (time1.Minutes != time2.Minutes)
            {
                return time1.Minutes < time2.Minutes;
            }
            else
            {
                return time1.Seconds < time2.Seconds;
            }
        }

        /// <summary>
        /// Calculates number of seconds to a specific moment, which could be negative
        /// </summary>
        public int TimeToMoment(Time moment)
        {
            return (moment.Hours - this.hours) * MinutesInHour * SecondsInMinute + 
                (moment.Minutes - this.minutes) * SecondsInMinute + 
                (moment.Seconds - this.seconds);
        }
    }
}
