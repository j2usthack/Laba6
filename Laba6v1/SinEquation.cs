using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba6v1
{
    public class SinEquation : Equation
    {
        private readonly double a;

        public SinEquation(double a)
        {
            this.a = a;
        }

        public override double GetValue(double x)
        {
            if (x == 0) return 0;
            return Math.Sin(a * x) / x;
        }
    }
}
