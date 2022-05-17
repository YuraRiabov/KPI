using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB_Lab2._5_cs
{
    public abstract class Prism
    {
        public double Height { get; set; }
        public double SideLength { get; set; }
        public abstract double CalculateSurface();
        public abstract double CalculateBaseSurface();

        public double CalculateVolume()
        {
            return CalculateBaseSurface() * Height;
        }

        protected Prism(double height, double sideLength)
        {
            Height = height;
            SideLength = sideLength;
        }
    }
}
