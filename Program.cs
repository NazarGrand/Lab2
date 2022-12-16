using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public double AmountOfExpectedLosses(double[] losses, double[] p)
        {
            double res = 0;
            for(int i = 0; i < losses.Length; i++)
                res += losses[i] * p[i];

            return res;
        }
        

        public double Variation(double[] losses, double[] p)
        {
            double expLosses = AmountOfExpectedLosses(losses, p);

            double res = 0;
            for (int i = 0; i < losses.Length; i++)
                res += Math.Pow(losses[i] - expLosses, 2) * p[i];
            return res;
        }

        public double CoefVariation(double[] losses, double[] p)
        {
            double middleSquareDeviation = Math.Sqrt(Variation(losses, p));
            double expLosses = AmountOfExpectedLosses(losses, p);
            return middleSquareDeviation / expLosses;
        }

        static void Main(string[] args)
        {
            double[] losses = new double[4] { 300, 100, 200, 400 };
            double[] p = new double[4] { 0.2, 0.3, 0.1, 0.4 };

            Console.WriteLine(new String('-', 59));

            Console.Write("| Losses  ");
            for (int i = 0; i < losses.Length; i++)
            {
                Console.Write($"| {losses[i],-10}");
                
            }

            Console.WriteLine("|");
            Console.WriteLine(new String('-', 59));

            Console.Write("| P       ");
            for (int i = 0; i < p.Length; i++)
            {
                Console.Write($"| {p[i],-10}");
            }

            Console.WriteLine("|");
            Console.WriteLine(new String('-', 59));

            Console.WriteLine($"\nAmountOfExpectedLosses = {new Program().AmountOfExpectedLosses(losses,p)}");
            Console.WriteLine($"\nVariation = {new Program().Variation(losses,p)}");
            Console.WriteLine($"\nCoefVariation = {new Program().CoefVariation(losses,p)}");
            Console.ReadKey();
        }
    }
}
