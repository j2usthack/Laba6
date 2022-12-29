using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba6v1
{
    public class IntegratedEquation : Equation
    {
        private readonly Equation equation;
        private readonly double x1;
        private readonly double x2;
        private readonly double h;

        public IntegratedEquation(Equation equation, double x1, double x2, double h)
        {
            this.equation = equation;
            this.x1 = x1;
            this.x2 = x2;
            this.h = h;
        }

        public override double GetValue(double x)
        {
            double result = 0;
            for (double i = x1; i < x; i += h)
            {
                result += equation.GetValue(i) * h;
            }
            return result;
        }
    }
}
