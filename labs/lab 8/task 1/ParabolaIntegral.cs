using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    public class ParabolaIntegral : Integral
    {
        public ParabolaIntegral(Func func, double a, double b, double h) : base(func, a, b, h)
        {
        }

        public ParabolaIntegral(Func func, double a, double b, int n) : base(func, a, b, n)
        {
        }

        double GetValue(double value)
        {
            return function(value);
        }

        public double CalcIntegral()
        {
            double result = GetValue(a) + GetValue(b);
            for (int i = 1; i < n; ++i)
                result += (i % 2 == 1 ? 4 : 2) * GetValue(a + h * i);
            return result * h / 3;
        }

        public double GetErrorDiap()
        {
            ParabolaIntegral trapezium = new ParabolaIntegral(function, a, b, n * 2);
            return Math.Abs(trapezium.CalcIntegral() - this.CalcIntegral()) / 15;
        }
    }
}
