using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace slu
{
    struct Table
    {
        public int N { get; set; }
        public double [][] Field { get; set; }

        public Table(int n)
        {
            N = n;
            Field = new double[N][];
        }

        public static Table ReadTableFromFile(string fileName)
        {
            Table table;
            using (StreamReader reader = new StreamReader(fileName))
            {
                table = new Table(int.Parse(reader.ReadLine()));
                for (int i = 0; i < table.N; ++i)
                    table.Field[i] = reader.ReadLine().Split(' ').Select(n => double.Parse(n)).ToArray();
                reader.Close();
            }
            return table;
        }
    }
}
