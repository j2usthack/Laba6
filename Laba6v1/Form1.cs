using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Laba6v1
{
    public partial class Form1 : Form
    {
        private bool ValidateInputs(TextBox textBox1, TextBox textBox2, out double x1, out double x2)
        {
            x2 = 0;
            x1 = 0;
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Поле X1 и X2 не может быть пустым!");
                return false;
            }
            // check if the TextBox controls contain valid numeric values
            if (!double.TryParse(textBox1.Text, out x1) || !double.TryParse(textBox2.Text, out x2))
            {
                MessageBox.Show("Пожалуйста введите корректное значение X1 и X2!");
                return false;
            }
            // check if x2 > x1
            if (x2 <= x1)
            {
                MessageBox.Show("Значение X2 должно быть больше значения X1!");
                return false;
            }
            return true;
        }
        //void IsEmpty()
        //{
        //    double x1, x2;
        //    // check if the TextBox controls contain valid numeric values
        //    if (!double.TryParse(textBox1.Text, out x1) || !double.TryParse(textBox2.Text, out x2))
        //    {
        //        MessageBox.Show("Пожалуйста введите корректные значения X1 и X2");
        //        return;
        //    }
        //    // check if x2 > x1
        //    if (x2 <= x1)
        //    {
        //        MessageBox.Show("Значение X2 должно быть больше значения X1");
        //        return;
        //    }
        //}
        //List<double> xValues = new List<double>();
        //List<double> yValues = new List<double>();
        void DrawIntegrateFunction(double x1, double x2, Series series, Equation equation)
        {
            RectangleIntegratorv2 integrator = new RectangleIntegratorv2(equation, 0.1);
            // calculate the integrated function on the given segment

            Equation integratedEquation = integrator.Integrate(x1, x2);

            // evaluate the integrated function at a number of points within the desired range
            int numPoints = 10000;
            double step = (x2 - x1) / numPoints;
            double[] xValues = new double[numPoints + 1];
            double[] yValues = new double[numPoints + 1];
            for (int i = 0; i <= numPoints; i++)
            {
                xValues[i] = x1 + i * step;
                yValues[i] = integratedEquation.GetValue(xValues[i]);
            }
            // bind the data to the Series object
            series.Points.DataBindXY(xValues, yValues);

            // set the ChartType and XValueType/YValueType properties
            series.ChartType = SeriesChartType.Point;
            series.XValueType = ChartValueType.Double;
            series.YValueType = ChartValueType.Double;

            // customize the appearance and behavior of the Chart and Series
            series.Name = "My Function";
            series.Color = Color.Red;
            series.BorderWidth = 3;
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 8;
            // bind the data to the Series object and display the chart
            chart1.Series["Series1"].Points.DataBindXY(xValues, yValues);
        }
        void DrawFunction(double x1, double x2, Series series, Equation equation)
        {
            // calculate the value of the function at a number of points within the desired range
            int numPoints = 10000;
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
            series.ChartType = SeriesChartType.Point;
            series.XValueType = ChartValueType.Double;
            series.YValueType = ChartValueType.Double;

            // customize the appearance and behavior of the Chart and Series
            series.Name = "My Function";
            series.Color = Color.Red;
            series.BorderWidth = 3;
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 8;
            chart1.Series["Series1"].Points.DataBindXY(xValues, yValues);
        }
        public Form1()
        {
            InitializeComponent();

            //xValues.Add(0);
            //yValues.Add(1);

            //xValues.Add(1);
            //yValues.Add(3);

            //xValues.Add(10);
            //yValues.Add(3.5);
            // create a new Chart control
            //Chart chart = new Chart();

            //// add a Series object to the Chart
            //Series series = new Series();
            //chart.Series.Add(series);

            //// define an Equation object representing the function to be plotted
            //Equation equation = new QuadEquation(1, 2, 3);

            // calculate the value of the function at a number of points within the desired range
            //int numPoints = 100;
            //double x1 = -10;
            //double x2 = 10;
            //double step = (x2 - x1) / numPoints;
            //for (int i = 0; i <= numPoints; i++)
            //{
            //    double x = x1 + i * step;
            //    double y = equation.GetValue(x);
            //    series.Points.AddXY(x, y);
            //}

            //// set the ChartType and XValueType/YValueType properties
            //series.ChartType = SeriesChartType.Line;
            //series.XValueType = ChartValueType.Double;
            //series.YValueType = ChartValueType.Double;

            // customize the appearance and behavior of the Chart and Series
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //// create a new Chart control
            //Chart chart = new Chart();

            //// add a Series object to the Chart
            //Series series = new Series();
            //chart.Series.Add(series);

            //// define an Equation object representing the function to be plotted
            //Equation equation = new SinEquation(1);

            //// calculate the value of the function at a number of points within the desired range
            //int numPoints = 100;
            //double x1 = -10;
            //double x2 = 10;
            //double step = (x2 - x1) / numPoints;
            //double[] xValues = new double[numPoints + 1];
            //double[] yValues = new double[numPoints + 1];
            //for (int i = 0; i <= numPoints; i++)
            //{
            //    xValues[i] = x1 + i * step;
            //    yValues[i] = equation.GetValue(xValues[i]);
            //}

            //// bind the data to the Series object
            //chart1.Series["Series1"].Points.DataBindXY(xValues, yValues);

            //// set the ChartType and XValueType/YValueType properties
            //series.ChartType = SeriesChartType.Line;
            //series.XValueType = ChartValueType.Double;
            //series.YValueType = ChartValueType.Double;

            //// customize the appearance and behavior of the Chart and Series
            //// set the ChartType and XValueType/YValueType properties
            ////series1.ChartType = SeriesChartType.Line;
            ////series1.XValueType = ChartValueType.Double;
            ////series1.YValueType = ChartValueType.Double;

            //// customize the appearance and behavior of the Chart and Series
            //chart1.Titles.Add("My Chart");
            //chart1.Titles[0].Text = "My Function";
            //chart1.Titles[0].Font = new Font("Arial", 20, FontStyle.Bold);
            //chart1.Titles[0].ForeColor = Color.DarkBlue;
            //chart1.ChartAreas[0].AxisX.Title = "X";
            //chart1.ChartAreas[0].AxisY.Title = "Y";
            //chart1.ChartAreas[0].AxisX.TitleFont = new Font("Arial", 12, FontStyle.Bold);
            //chart1.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 12, FontStyle.Bold);
            //chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            //chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            //chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            //chart1.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            //chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            //chart1.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            //chart1.Series["Series1"].Points.DataBindXY(xValues, yValues);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x1, x2;
            if (!ValidateInputs(textBox1, textBox2, out x1, out x2))
            {
                return;
            }
            double x = double.Parse(textBox1.Text);
            double y = double.Parse(textBox2.Text);           
            // create a new Chart control
            Chart chart = new Chart();

            // add a Series object to the Chart
            Series series = new Series();
            chart.Series.Add(series);

            // define an Equation object representing the function to be plotted
            Equation equation = new SinEquation(2);
            DrawFunction(x1, x2, series, equation);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series["Series1"].Points.Clear();
            chart1.Titles.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double x1, x2;
            if (!ValidateInputs(textBox1, textBox2, out x1, out x2))
            {
                return;
            }
            double x = double.Parse(textBox1.Text);
            double y = double.Parse(textBox2.Text);
            // create a new Chart control
            Chart chart = new Chart();

            // add a Series object to the Chart
            Series series = new Series();
            chart.Series.Add(series);

            // define an Equation object representing the function to be plotted
            Equation equation = new QuadEquation(1, 2, 3);
            DrawFunction(x1, x2, series, equation);           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double x1, x2;
            if (!ValidateInputs(textBox1, textBox2, out x1, out x2))
            {
                return;
            }
            double x = double.Parse(textBox1.Text);
            double y = double.Parse(textBox2.Text);
            // create a new Chart control
            Chart chart = new Chart();

            // add a Series object to the Chart
            Series series = new Series();
            chart.Series.Add(series);

            // define an Equation object representing the function to be plotted
            Equation equation = new ModSinEquation(2);
            DrawFunction(x1, x2, series, equation);        
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double x1, x2;
            if (!ValidateInputs(textBox1, textBox2, out x1, out x2))
            {
                return;
            }
            double x = double.Parse(textBox1.Text);
            double y = double.Parse(textBox2.Text);
            // create a new Chart control
            Chart chart = new Chart();

            // add a Series object to the Chart
            Series series = new Series();
            chart.Series.Add(series);

            // define an Equation object representing the function to be plotted
            Equation equation = new CosEquation(2,2);
            DrawFunction(x1, x2, series, equation);            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double x1, x2;
            if (!ValidateInputs(textBox1, textBox2, out x1, out x2))
            {
                return;
            }
            double x = double.Parse(textBox1.Text);
            double y = double.Parse(textBox2.Text);
            // create a new Chart control
            Chart chart = new Chart();

            // add a Series object to the Chart
            Series series = new Series();
            chart.Series.Add(series);

            // define an Equation object representing the function to be plotted
            Equation equation = new ModSinXEquation(2);
            DrawFunction(x1, x2, series, equation);           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            double x1, x2;
            if (!ValidateInputs(textBox1, textBox2, out x1, out x2))
            {
                return;
            }
            double x = double.Parse(textBox1.Text);
            double y = double.Parse(textBox2.Text);
            // create a new Chart control
            Chart chart = new Chart();

            // add a Series object to the Chart
            Series series = new Series();
            chart.Series.Add(series);
           

            // define an Equation object representing the function to be plotted
            Equation equation = new CosXEquation(2);
            DrawFunction(x1, x2, series, equation);            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            double x1, x2;
            if (!ValidateInputs(textBox1, textBox2, out x1, out x2))
            {
                return;
            }
            double x = double.Parse(textBox1.Text);
            double y = double.Parse(textBox2.Text);
            // create a new Chart control
            Chart chart = new Chart();

            // add a Series object to the Chart
            Series series = new Series();
            chart.Series.Add(series);


            // define an Equation object representing the function to be plotted
            Equation equation = new QuadEquation(1,2,3);
            DrawIntegrateFunction(x1, x2, series, equation);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            double x1, x2;
            if (!ValidateInputs(textBox1, textBox2, out x1, out x2))
            {
                return;
            }
            double x = double.Parse(textBox1.Text);
            double y = double.Parse(textBox2.Text);
            // create a new Chart control
            Chart chart = new Chart();

            // add a Series object to the Chart
            Series series = new Series();
            chart.Series.Add(series);


            // define an Equation object representing the function to be plotted
            Equation equation = new SinX(1);
            DrawFunction(x1, x2, series, equation);
        }
    }
}
