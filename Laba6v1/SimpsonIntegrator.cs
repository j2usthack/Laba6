using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba6v1
{
    public class SimpsonIntegrator : Integrator
    {
        public override string MethodName
        {
            get { return "Метол Симпсона(Парабол)"; }
        }
        public SimpsonIntegrator(Equation equation) : base(equation)
        {

        }
        public override double Integrate(double x1, double x2)
        {
            // проверьте правильность параметров
            if (x1 >= x2)
            {
                throw new ArgumentException("Правое поле масштабирования должно быть больше левого!");
            }

            // разделите исходный сегмент на N точек
            int N = 100;
            // вычислите ширину интервала
            double h = (x2 - x1) / N;
            double sum = 0; // "накопитель" для значения интеграла
            for (int i = 0; i < N; i++)
            {
                // вычислите площадь параболы и добавьте ее к сумме
                double y1 = equation.GetValue(x1 + i * h);
                double y2 = equation.GetValue(x1 + (i + 1) * h);
                double y3 = equation.GetValue(x1 + (i + 0.5) * h);
                sum = sum + (y1 + 4 * y3 + y2) * h / 6;
            }
            return sum;

        }
    }
}
