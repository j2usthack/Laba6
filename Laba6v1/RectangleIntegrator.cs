using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba6v1
{
    public class RectangleIntegrator : Integrator
    {
        public override string MethodName
        {
            get { return "Метод прямоугольников"; }
        }

        public RectangleIntegrator(Equation equation) : base(equation) { }

        public override double Integrate(double x1, double x2)
        {
            // проверка правильности параметров
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
                // вычислите площадь прямоугольника и добавьте ее к сумме
                sum = sum + equation.GetValue(x1 + i * h) * h;
            }
            return sum;
        }
    }
}
