using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB_Lab2._5_cs
{
    internal class Prism4 : Prism
    {
        public Prism4(double height, double sideLength) : base(height, sideLength)
        {}

        public override double CalculateBaseSurface()
        {
            return SideLength * SideLength;
        }

        public override double CalculateSurface()
        {
            return CalculateBaseSurface() * 2 + SideLength * Height * 4;
        }

        public override double CalculateVolume()
        {
            return CalculateBaseSurface() * Height;
        }
    }
}
