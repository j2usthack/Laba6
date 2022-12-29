using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba6v1
{
    public class MonteCarloIntegrator : Integrator
    {
        public override string MethodName
        {
            get { return "Метод Монте-Карло"; }
        }
        private readonly int N; // количество точек, подлежащих "наброску"

        public MonteCarloIntegrator(Equation equation, int N) : base(equation)
        {
            this.N = N;
        }

        public override double Integrate(double x1, double x2)
        {
            // проверьте правильность параметров
            if (x1 >= x2)
            {
                throw new ArgumentException("Правое поле масштабирования должно быть больше левого!");
            }

            // найдите максимальное и минимальное значения y на отрезке
            double yMin = double.MaxValue;
            double yMax = double.MinValue;
            for (int i = 0; i <= 100; i++)
            {
                double y = equation.GetValue(x1 + i * (x2 - x1) / 100);
                yMin = Math.Min(yMin, y);
                yMax = Math.Max(yMax, y);
            }

            // ограничить функцию прямоугольником
            double width = x2 - x1;
            double height = yMax - yMin;
            double Spr = width * height;

            // нарисовать N точек в прямоугольнике
            int K = 0; // количество точек, попадающих под график функции
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                double x = x1 + rnd.NextDouble() * width;
                double y = yMin + rnd.NextDouble() * height;
                if (y > equation.GetValue(x))
                {
                    K++;
                }
            }

            // вычислите площадь, ограниченную функцией и координатными осями
            return Spr * K / N;
        }
    }

}
