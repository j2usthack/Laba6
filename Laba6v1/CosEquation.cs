using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba6v1
{
    public class CosEquation : Equation
    {
        private readonly double a;
        private readonly double b;

        public CosEquation(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public override double GetValue(double x)
        {
            return x * x * Math.Cos(x - a) / b;
        }
    }
}
