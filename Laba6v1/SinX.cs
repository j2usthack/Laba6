using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba6v1
{
    public class SinX : Equation
    {
        private readonly double a;

        public SinX(double a)
        {
            this.a = a;
        }

        public override double GetValue(double x)
        {
            if (x == 0) return 0;
            return Math.Sin(x);
        }
    }
}
