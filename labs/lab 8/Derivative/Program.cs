using System;

using Utils;

namespace Derivative
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите функцию: ");
            for (int i = 0; i < Functions.FuncsName.Length; ++i)
            {
                Console.WriteLine($"{i}: {Functions.FuncsName[i]}");
            }
            int index = int.Parse(Console.ReadLine());
            Func<double, double> func = Functions.Funcs[index];
            Console.WriteLine("Введите h");
            double h = double.Parse(Console.ReadLine());
            Console.WriteLine($"Точка: {Functions.C[index].Item1}");
            (double a, double b) = Functions.C[index];
            a += h;

            Console.WriteLine($"Правая производная: {FirstDerivativeRight(a, h, func)}");
            Console.WriteLine($"Левая производная: {FirstDerivativeLeft(a, h, func)}");
            Console.WriteLine($"Центральная производная: {FirstDerivativeMiddle(a, h, func)}");
            Console.WriteLine($"Вторая производная: {SecondDerivative(a, h, func)}");

            Console.ReadLine();
        }

        static double FirstDerivativeRight(double a, double h, Func<double, double> func)
        {
            double x1 = a + h;
            double y = func(a);
            double y1 = func(x1);
            return (y1 - y) / h;
        }

        static double FirstDerivativeLeft(double a, double h, Func<double, double> func)
        {
            double x1 = a - h;
            double y = func(a);
            double y1 = func(x1);
            return (y - y1) / h;
        }

        static double FirstDerivativeMiddle(double a, double h, Func<double, double> func)
        {
            double x1 = a - h;
            double x2 = a + h;
            double y1 = func(x1);
            double y2 = func(x2);
            return (y2 - y1) / (2 * h);
        }

        static double SecondDerivative(double a, double h, Func<double, double> func)
        {
            double y = func(a);
            double y1 = func(a + h);
            double y2 = func(a - h);

            return (y1 - 2 * y + y2) / (h * h);
        }
    }
}
