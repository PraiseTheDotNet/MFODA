using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    abstract class Integral
    {
        protected Func function;
        protected double a, b, h;
        protected int n;

        public Integral(Func func, double a, double b, double h)
        {
            this.function = func;
            this.a = a;
            this.b = b;
            this.h = h;
            this.n = (int)((b - a) / h);

        }

        public Integral(Func func, double a, double b, int n) : this(func, a, b, (b - a) / n)
        {
            this.n = n;
        }
    }
}
