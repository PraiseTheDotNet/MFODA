using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    public enum RectangleIntegralType
    {
        Left,
        Center,
        Right
    }

    class RectangleIntegral : Integral
    {
        public RectangleIntegral(Func func, double a, double b, double h) : base(func, a, b, h)
        {

        }

        public RectangleIntegral(Func func, double a, double b, int n) : base(func, a, b, (b-a)/n)
        {
        }

        double GetValue(double value, RectangleIntegralType type)
        {
            switch(type)
            {
                case RectangleIntegralType.Left: return function(value);
                case RectangleIntegralType.Right: return function(value + h);
                default: return function(value + h / 2);
            }
        }

        public double CalcIntegral(RectangleIntegralType type)
        {
            double result = 0;
            for (int i = 0; i < n; ++i)
                result += GetValue(a + i * h, type);
            return result * h;
        }

        public double GetErrorDiap(RectangleIntegralType type)
        {
            RectangleIntegral temp = new RectangleIntegral(this.function, a, b, n * 2);
            return Math.Abs(temp.CalcIntegral(type) - this.CalcIntegral(type));
        }
    }
}
