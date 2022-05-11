using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB_Lab2._5_cs
{
    public class IOManager
    {
        public List<Prism> GetPrisms()
        {
            List<Prism> prisms = new List<Prism>();
            Console.Write("Enter number of prisms you want to enter: ");
            if (int.TryParse(Console.ReadLine(), out int prismCount))
            {
                for (int i = 0; i < prismCount; i++)
                {
                    Console.Write("Enter prism in format: number of sides(3 or 4), side length, heigth: ");
                    string[] input = Console.ReadLine().Split(',');
                    try
                    {
                        if (int.Parse(input[0]) == 3)
                        {
                            prisms.Add(new Prism3(double.Parse(input[1]), double.Parse(input[2])));
                        }
                        else if (int.Parse(input[0]) == 4)
                        {
                            prisms.Add(new Prism4(double.Parse(input[1]), double.Parse(input[2])));
                        }
                        else
                        {
                            Console.WriteLine("Wrong number of sides entered, try inputing this prism again");
                            i--;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Something went wrong, try inputing this prism again");
                        i--;
                    }
                }
            }
            return prisms;
        }
        private (double volumeSum, double surfaceSum) ProcessPrisms(List<Prism> prisms)
        {
            double volumeSum = 0;
            double surfaceSum = 0;
            foreach (Prism prism in prisms)
            {
                if (prism is Prism3)
                {
                    volumeSum += prism.CalculateVolume();
                }
                else if (prism is Prism4)
                {
                    surfaceSum += prism.CalculateSurface();
                }
            }
            return (volumeSum, surfaceSum);
        }
        public void GetVolumeSurfaceData(List<Prism> prisms)
        {
            (double volumeSum, double surfaceSum) = ProcessPrisms(prisms);
            Console.WriteLine($"Sum of volumes of triangular prisms: {volumeSum}");
            Console.WriteLine($"Sume of surfaces of square prisms: {surfaceSum}");
        }
    }
}
