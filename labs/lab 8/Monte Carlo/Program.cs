using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using task_1;

using Utils;

namespace Monte_Carlo
{
    class Program
    {
        static Func func;

        static void Main(string[] args)
        {
            Console.WriteLine("Выберите функцию: ");
            for (int i = 0; i < Functions.FuncsName.Length; ++i)
            {
                Console.WriteLine($"{i}: {Functions.FuncsName[i]}");
            }
            int index = int.Parse(Console.ReadLine());
            func = new Func(Functions.Funcs[index]);
            Console.WriteLine($"Указанный диапазон: {Functions.Diaps[index]}");
            (double a, double b) = Functions.Diaps[index];
            int n = (int)ReadDouble("Введите число N");
            double result = MonteCarlo(a, b, n);
            Console.WriteLine($"Метод Монте-Карло: {result:f5}");
            RectangleIntegral rectangle = new RectangleIntegral(func, a, b, n);
            TrapeziumIntegral trapeziumIntegral = new TrapeziumIntegral(func, a, b, n);
            ParabolaIntegral parabolaIntegral = new ParabolaIntegral(func, a, b, n * 2);

            for (int i = 0; i < 3; ++i)
                Console.WriteLine($"{task_1.Program.RectangleTypeName[i]} прямоугольников: {rectangle.CalcIntegral((RectangleIntegralType)i):f5} с погрешностью: {rectangle.GetErrorDiap((RectangleIntegralType)i):f5}");

            Console.WriteLine($"Трапеция: {trapeziumIntegral.CalcIntegral():f5} с погрешностью: {trapeziumIntegral.GetErrorDiap():f5}");
            Console.WriteLine($"Парабола: {parabolaIntegral.CalcIntegral():f5} с погрешностью: {parabolaIntegral.GetErrorDiap():f5}");



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
