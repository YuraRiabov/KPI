using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB_Lab2._5_cs
{
    public class Program
    {
        static void Main()
        {
            IOManager iOManager = new IOManager();
            List<Prism> prisms = iOManager.GetPrisms();
            iOManager.GetVolumeSurfaceData(prisms);
        }
    }
}