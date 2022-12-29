using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba6v1
{
    public class ModSinEquation : Equation
    {
        private readonly double a;

        public ModSinEquation(double a)
        {
            this.a = a;
        }

        public override double GetValue(double x)
        {
            return x * Math.Abs(Math.Sin(a * x));
        }
    }
}
