using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    /// <summary>
    /// Класс с функциями
    /// </summary>
    public static class Functions
    {
        /// <summary>
        /// Функции
        /// </summary>
        public static readonly Func<double, double>[] Funcs =
        {
            (x) => Math.Sqrt(1 + Math.Pow(Math.E, -x)),
            (x) => 1 / (Math.Pow(x, Math.Sqrt(Math.Pow(x, 3) + 4))),
            (x) => Math.Cos(3 * x) / Math.Pow(1 - Math.Cos(3 * x), 2),
            (x) => Math.Pow(Math.E, 2 * x) * Math.Sin(3 * x)
        };

        public static readonly string[] FuncsName =
        {
            "Sqrt(1 + e ^ -x)",
            "1 / (x ^ Sqrt(x ^ 3 + 4))",
            "Cos(3x) / ((1 - Cos(3x)) ^ 2)",
            "e ^ (2x) * Sin(3x)"
        };

        /// <summary>
        /// Диапазоны значений
        /// </summary>
        public static readonly (double, double)[] Diaps =
        {
            (0.4, 1.2),
            (0.18, 0.98),
            (0.8, 1.6),
            (0.4, 1.2)
        };

        public static readonly (double, double)[] C =
        {
            (0.5, 0.6),
            (0.5, 0.6),
            (-1, -0.9),
            (2, 2.1)
        };
    }
}
