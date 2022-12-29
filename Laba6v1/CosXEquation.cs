using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba6v1
{
    public class CosXEquation : Equation
    {
        private readonly double a;

        public CosXEquation(double a)
        {
            this.a = a;
        }

        public override double GetValue(double x)
        {
            return x * Math.Cos(x) / a;
        }
    }
}
