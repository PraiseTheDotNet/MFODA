using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middle
{
    class RungeKutta
    {
        private readonly double a, b, h, y0;
        private readonly int n;
        private double[] result;
        private double x, y;

        public Func<double, double, double> Function { get; set; }

        public RungeKutta(double a, double b, double h, double y0)
        {
            this.a = a;
            this.b = b;
            this.h = h;
            this.y0 = y0;
            this.n = (int)((b - a) / h);
        }

        public void Calc()
        {
            result = new double[n + 1];
            x = a;
            result[0] = y0;
            y = y0;
            for(int i = 1; i <= n; ++i)
            {
                result[i] = y + GetDeltaY();
                y = result[i];
                x += h;
            }
        }

        public RungeKutta(double a, double b, int n, double y0): this(a, b, (b-a)/n, y0)
        {
            this.n = n;
        }

        private double GetDeltaY()
        {
            double k1 = GetK1();
            double k2 = GetK2(k1);
            double k3 = GetK3(k2);
            double k4 = GetK4(k3);

            return (k1 + 2 * k2 + 2 * k3 + k4) / 6;
        }

        private double GetK1()
        {
            return h * Function(x, y);
        }

        private double GetK2(double k1)
        {
            return h * Function(x + h / 2, y + k1 / 2);
        }

        private double GetK3(double k2)
        {
            return h * Function(x + h / 2, y + k2 / 2);
        }

        private double GetK4(double k3)
        {
            return h * Function(x + h, y + k3);
        }

        public double[] GetResult() => result;

        public double GetErrorRange()
        {
            RungeKutta temp = new RungeKutta(a, b, n * 2, y0)
            {
                Function = this.Function
            };
            temp.Calc();
            return Math.Abs(this.result.Last() - temp.result.Last()) / 30;
        }
    }
}
