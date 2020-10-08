using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middle
{
    class Program
    {
        static Func<double, double, double>[] Funcs =
        {
            (x, y) => x * x + y * y,
            (x, y) => Math.Cos(x + y),
            (x, y) => Math.Pow(Math.E, -x) - y,
            (x, y) => Math.Sqrt(x) + y
        };

        static string[] FuncNames =
        {
            "y' = x^2 + y^2",
            "y' = cos(x + y)",
            "y' = e^-x - y",
            "y' = sqrt(x) + y"
        };

        static (double, double)[] Intervals =
        {
            (0, 1),
            (0, 1),
            (0, 1),
            (0, 1)
        };

        static double[] Y0 =
        {
            0.4,
            0.4,
            1,
            1
        };

        static void Main(string[] args)
        {
            while (true)
            {
                var rungeKutta = ReadFromConsole();
                rungeKutta.Calc();
                Console.WriteLine($"Ответ: {rungeKutta.GetResult().Last()}. Погрешность: {rungeKutta.GetErrorRange()}");
            }
        }

        static RungeKutta ReadFromConsole()
        {
            var func = GetFuncIndex();
            (double a, double b) = Intervals[func];
            Console.WriteLine($"Интервал: [{a}, {b}]");
            double y0 = Y0[func];
            Console.WriteLine($"y(0) = {y0}");
            int n = ReadInt("Введите n (число разбиений):");
            return new RungeKutta(a, b, n, y0)
            {
                Function = Funcs[func]
            };
        }

        static int GetFuncIndex()
        {
            int index = -1;
            do
            {
                Console.WriteLine("Выберите функцию");
                for (int i = 0; i < Funcs.Length; ++i)
                {
                    Console.WriteLine($"{i}. {FuncNames[i]}");
                }
                index = ReadInt();
            }
            while (index == -1 || index >= Funcs.Length);

            return index;
        }

        static int ReadInt(string message = "")
        {
            Console.WriteLine(message);
            return int.Parse(Console.ReadLine());
        }
    }
}
