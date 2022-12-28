using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba6
{
    public class ModSinXEquation : Equation
    {
        private readonly double a;

        public ModSinXEquation(double a)
        {
            this.a = a;
        }

        public override double GetValue(double x)
        {
            return a * x * Math.Abs(Math.Sin(x));
        }
    }
}
