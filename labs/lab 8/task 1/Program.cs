using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Utils;

namespace task_1
{
    public delegate double Func(double x);

    public class Program
    {
        static Func func;

        public static string[] RectangleTypeName =
        {
            "Левых",
            "Центральных",
            "Правых"
        };

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
            int n;
            //a = ReadDouble("Введите начало отрезка");
            //b = ReadDouble("Введите конец отрезка");
            n = (int)ReadDouble("Введите число разбиений");

            RectangleIntegral rectangle = new RectangleIntegral(func, a, b, n);
            TrapeziumIntegral trapeziumIntegral = new TrapeziumIntegral(func, a, b, n);
            ParabolaIntegral parabolaIntegral = new ParabolaIntegral(func, a, b, n * 2);

            for(int i = 0; i < 3; ++i)
                Console.WriteLine($"{RectangleTypeName[i]} прямоугольников: {rectangle.CalcIntegral((RectangleIntegralType)i):f5} с погрешностью: {rectangle.GetErrorDiap((RectangleIntegralType)i):f5}");

            Console.WriteLine($"Трапеция: {trapeziumIntegral.CalcIntegral():f5} с погрешностью: {trapeziumIntegral.GetErrorDiap():f5}");
            Console.WriteLine($"Парабола: {parabolaIntegral.CalcIntegral():f5} с погрешностью: {parabolaIntegral.GetErrorDiap():f5}");

            Console.ReadKey();
        }
            
        static double ReadDouble(string message = "")
        {
            Console.WriteLine(message);
            return double.Parse(Console.ReadLine());
        }
    }
}
