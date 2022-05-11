using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB_Lab2._5_cs
{
    public class Prism3 : Prism
    {
        public Prism3(double height, double sideLength) : base(height, sideLength)
        {}

        public override double CalculateBaseSurface()
        {
            return SideLength * SideLength * Math.Sqrt(3) / 4;
        }

        public override double CalculateSurface()
        {
            return CalculateBaseSurface() * 2 + SideLength * Height * 3;
        }
    }
}
