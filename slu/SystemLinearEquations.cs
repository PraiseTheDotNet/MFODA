using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slu
{
    struct SystemLinearEquations
    {
        const double Accuracy = 1E-9;

        public static List<double> ChoiceGauss(Table table)
        {
            double[][] tempField = Clone(table);
            int[] positions = new int[table.N];
            for (int i = 0; i < table.N; ++i)
                positions[i] = i;
            //Array.Copy(table.Field, tempField, table.N);
            for (int i = 0; i < table.N; ++i)
            {
                Console.WriteLine("Input");
                Console.WriteLine(ConvertArrayToString(tempField));
                Pair max = GetMaxValue(tempField, i);
                SwapArray(tempField, i, max.Y);
                SwapColumns(tempField, i, max.X, positions);
                Console.WriteLine("Update:");
                Console.WriteLine(ConvertArrayToString(tempField));
                CalcTable(tempField, i);
                Console.WriteLine("Calc:");
                Console.WriteLine(ConvertArrayToString(tempField));
            }

            double[] x = CalcX(tempField).ToArray();
            Array.Sort(x, positions);
            return x.Reverse().ToList();
        }

        private static void CalcTable(double[][] field, int y)
        {
            for(int i = y + 1; i < field.Length; ++i)
            {
                double coef = -field[i][y] / field[y][y];
                for (int j = y; j < field[i].Length; ++j)
                    field[i][j] += coef * field[y][j];
            }
        }

        private static Pair GetMaxValue(double[][] array, int y = 0)
        {
            int mX = 0, mY = y;
            for(int i = y; i < array.Length; ++i)
                for(int j = 0; j < array[i].Length - 1; ++j)
                    if(Math.Abs(array[i][j]) > Math.Abs(array[mY][mX]))
                    {
                        mX = j;
                        mY = i;
                    }

            return new Pair(mX, mY);
        }

        private static void SwapArray(double[][] field, int first, int second)
        {
            double[] temp = field[first];
            field[first] = field[second];
            field[second] = temp;
        }

        private static void SwapColumns(double[][] field, int first, int second, int[] indexs = null)
        {
            for(int i = 0; i < field.Length; ++i)
            {
                Swap(ref field[i][first], ref field[i][second]);
            }
            if(indexs != null)
                Swap(ref indexs[first], ref indexs[second]);
        }


        private static void Swap<T>(ref T first, ref T second)
        {
            T t = first;
            first = second;
            second = t;
        }

        private static string ConvertArrayToString(double[][] field)
        {
            StringBuilder builder = new StringBuilder((field.Length + 1) * (field.Length + 2));
            for(int i = 0; i < field.Length; ++i)
            {
                for (int j = 0; j < field[i].Length; ++j)
                    builder.Append(field[i][j] + "\t");
                builder.Append("\n");
            }
            return builder.ToString();
        }

        private static List<double> CalcX(double[][] field)
        {
            List<double> result = new List<double>();
            for(int i = field.Length - 1; i >= 0; --i)
            {
                double res = field[i][field[i].Length - 1];
                for (int j = 0; j < result.Count; ++j)
                    res -= result[j] * field[i][field[i].Length - 2 - j];
                res /= field[i][field[i].Length - 2 - result.Count];
                result.Add(res);
            }
            return result;
        }

        public static double Determinant(double[][] myVect)
        {
            double result = 1, div = 0;
            int size = myVect.Length;
            double[][] work = new double[size][];
            for (int i = 0; i < size; ++i)
            {
                work[i] = new double[size];
                for (int g = 0; g < size; ++g)
                    work[i][g] = myVect[i][g];
            }
            for (int i = 0; i < size; ++i)
            {
                int g = i;
                for (int j = i + 1; j < size; j++)
                {
                    if (Math.Abs(work[j][i]) > Math.Abs(work[g][i]))
                        g = j;
                }

                if (Math.Abs(work[g][i]) < Accuracy)
                {
                    result = 0;
                    break;
                }
                Swap(ref work[i], ref work[g]);
                if (i != g)
                    result *= -1;

                for (int j = i + 1; j < size; j++)
                {
                    if (work[j][i] != 0)
                    {
                        div = work[j][i] / work[i][i];
                        for (int k = i; k < size; k++)
                            work[j][k] -= work[i][k] * div;
                    }
                }
                result *= work[i][i];
            }
            return result;
        }

        public static List<double> Kramer(Table table)
        {
            double[][] workField = Clone(table);
            double det = Determinant(table.Field);
            List<double> result = new List<double>();
            for(int i = 0; i < table.N; ++i)
            {
                SwapColumns(workField, i, table.N);
                result.Add(Determinant(workField) / det);
                SwapColumns(workField, i, table.N);
            }
            return result;
        }

        private static double[][] Clone(Table table)
        {
            double[][] tempField = new double[table.N][];
            for (int i = 0; i < table.N; ++i)
            {
                tempField[i] = new double[table.N + 1];
                for (int j = 0; j < table.Field[i].Length; ++j)
                    tempField[i][j] = table.Field[i][j];
            }

            return tempField;
        }


    }

    struct Pair
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Pair(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
