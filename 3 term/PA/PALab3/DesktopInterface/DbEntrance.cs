using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopInterface
{
    public class DbEntrance : IComparable
    {
        public int Key { get; set; }
        public string Value { get; set; }
        public int CompareTo(object? obj)
        {
            if (obj is DbEntrance another)
            {
                return Key.CompareTo(another.Key);
            }
            return -1;
        }
    }
}
