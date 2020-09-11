using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slu
{
    class Program
    {
        const string FolderPath = "../../Examples";
        static void Main(string[] args)
        {
            var files = Directory.GetFiles(FolderPath);
            for (int number = 0; number < files.Length; ++number)
            {
                Console.WriteLine($"{number}) {Path.GetFileNameWithoutExtension(files[number])}");
            }
            var id = int.Parse(Console.ReadLine());

            Table table = Table.ReadTableFromFile(files[id]);
            int i = 1;
            double det = SystemLinearEquations.Determinant(table.Field);
            Console.WriteLine($"Определитель: {det}");
            if (det != 0 && !double.IsInfinity(det) && !double.IsNaN(det))
            {
                List<double> result;
                Console.WriteLine("Выберите метод решения:\n 1 - Метод Гаусса с выбором главного элемента\n 2 - Краммер");
                if (int.Parse(Console.ReadLine()) == 1)
                {
                    Console.WriteLine("Метод Гаусса:");
                    result = SystemLinearEquations.ChoiceGauss(table);
                }
                else
                {
                    Console.WriteLine("Метод Крамера:");
                    result = SystemLinearEquations.Kramer(table);
                }
                foreach (var x in result)
                    Console.WriteLine($"x{i++}: {x}");
                Check(result, table);

            }
            Console.ReadKey();
        }

        static void Check(List<double> result, Table table)
        {
            Console.WriteLine("Проверка: ");
            for (int i = 0; i < table.N; ++i)
            {
                double calc = 0;
                for (int j = 0; j < table.N; ++j)
                    calc += result[j] * table.Field[i][j];
                Console.WriteLine($"{calc} {(Math.Round(calc) == Math.Round(table.Field[i][table.N]) ? "==" : "!=")} {table.Field[i][table.N]}");
            }
        }
    }
}
