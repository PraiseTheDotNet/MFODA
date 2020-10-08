using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monte_Carlo
{
    public delegate double Func(double x);
    class Program
    {
        static Func func = new Func((x) => 0.37 * Math.Pow(Math.E, Math.Sin(x)));

        static void Main(string[] args)
        {
            double a, b;
            int n;
            a = ReadDouble("Введите начало отрезка");
            b = ReadDouble("Введите конец отрезка");
            n = (int)ReadDouble("Введите число N");
            double result = MonteCarlo(a, b, n);
            Console.WriteLine($"Метод Монте-Карло: {result:f5}");



            Console.ReadKey();
        }

        static double ReadDouble(string message = "")
        {
            Console.WriteLine(message);
            return double.Parse(Console.ReadLine());
        }

        static double MonteCarlo(double a, double b, int n)
        {
            Random rand = new Random();
            double result = 0;
            for (int i = 0; i < n; ++i)
                result += func(a + (b - a) * rand.NextDouble());
            result = result * (b - a) / n;
            return result;
        }
    }
}
