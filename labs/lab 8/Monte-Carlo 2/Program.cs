using System;

namespace Monte_Carlo_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Random rand = new Random();
            double a = 0, b = 4;

            Func<double, double> cx = (x) => 3 * x;
            Func<double, double> dx = (x) => 8 * x;
            Func<double, double, double> func = (x, y) => Math.Sqrt(x + y);
            Console.WriteLine(@"Вычисление интеграла:
4   8x
| dx |  sqrt(x + y) dy
0   3x");

            double c = cx(a), d = dx(b);
            double sum = 0;
            Console.WriteLine("Введите N");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; ++i)
            {
                double x = a + (b - a) * rand.NextDouble();
                double y = c + (d - c) * rand.NextDouble();

                if (y > cx(x) && y < dx(x))
                {
                    sum += func(x, y);
                }
            }

            double res = sum * (b - a) * (d - c) / n;

            Console.WriteLine($"Ответ: {res}");
        }
    }
}