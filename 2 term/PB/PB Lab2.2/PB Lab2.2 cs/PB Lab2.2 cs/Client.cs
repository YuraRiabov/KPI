using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB_Lab2._2_cs
{
    public struct Client
    {
        public string Name { get; set; }
        public TimeOnly ComingTime { get; set; }
        public TimeOnly LeavingTime { get; set; }
    }
}
