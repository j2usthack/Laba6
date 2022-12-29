using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Laba6v1
{
    internal class Draw
    {
        void DrawFunction(double x1, double x2, Series series, Equation equation)
        {
            // calculate the value of the function at a number of points within the desired range
            int numPoints = 100;
            double step = (x2 - x1) / numPoints;
            double[] xValues = new double[numPoints + 1];
            double[] yValues = new double[numPoints + 1];
            for (int i = 0; i <= numPoints; i++)
            {
                xValues[i] = x1 + i * step;
                yValues[i] = equation.GetValue(xValues[i]);
            }

            // bind the data to the Series object
            series.Points.DataBindXY(xValues, yValues);

            // set the ChartType and XValueType/YValueType properties
            series.ChartType = SeriesChartType.Line;
            series.XValueType = ChartValueType.Double;
            series.YValueType = ChartValueType.Double;

            // customize the appearance and behavior of the Chart and Series
            series.Name = "My Function";
            series.Color = Color.Red;
            series.BorderWidth = 3;
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 8;
        }
    }
}
