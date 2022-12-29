using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba6v1
{
    public class RectangleIntegratorv2 : Integrator
    {
        public override string MethodName
        {
            get { return "Метод прямоугольников"; }
        }
        private readonly double h;

        public RectangleIntegratorv2(Equation equation, double h) : base(equation)
        {
            this.h = h;
        }

        public Equation Integrate(double x1, double x2)
        {
            return new IntegratedEquation(equation, x1, x2, h);
        }
    }
}
