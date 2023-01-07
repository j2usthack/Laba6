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
        private bool ValidateInputs(TextBox textBox1, TextBox textBox2, out double x1, out double x2, out double a1, out double b1, out double c1)
        {
            a1 = 0;
            b1 = 0;
            c1 = 0;
            x2 = 0;
            x1 = 0;
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Поле X1 и X2 не может быть пустым!");
                return false;
            }
            else if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Поле перемнной а не может быть пустым!");
                return false;
            }
            else if (string.IsNullOrEmpty(textBox4.Text) && textBox4.Enabled==true)
            {
                MessageBox.Show("Поле перемнной b не может быть пустым!");
                return false;
            }
            else if (string.IsNullOrEmpty(textBox5.Text) && textBox5.Enabled==true)
            {
                MessageBox.Show("Поле перемнной c не может быть пустым!");
                return false;
            }
            // проверка, содержат ли элементы управления текстовым полем допустимые числовые значения
            if (!double.TryParse(textBox1.Text, out x1) || !double.TryParse(textBox2.Text, out x2))
            {
                MessageBox.Show("Пожалуйста введите корректное значение X1 и X2!");
                return false;
            }
            // проверка если x2 > x1
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
            // вычислить интегрированную функцию на данном отрезке

            Equation integratedEquation = integrator.Integrate(x1, x2);

            richTextBox1.Text += "The result of the integration is: " + integratedEquation.GetValue(x2) + Environment.NewLine;

            // оценить интегрированную функцию в ряде точек в пределах желаемого диапазона
            int numPoints = 1000;
            double step = (x2 - x1) / numPoints;
            double[] xValues = new double[numPoints + 1];
            double[] yValues = new double[numPoints + 1];
            for (int i = 0; i <= numPoints; i++)
            {
                xValues[i] = x1 + i * step;
                yValues[i] = integratedEquation.GetValue(xValues[i]);
            }
            // привязать данные к объекту серии
            series.Points.DataBindXY(xValues, yValues);

            // установить ChartType и XValueType/YValueType properties
            series.ChartType = SeriesChartType.Point;
            series.XValueType = ChartValueType.Double;
            series.YValueType = ChartValueType.Double;

            // настройка внешнего вида и поведения диаграммы и ряда
            series.Name = "My Function";
            series.Color = Color.Red;
            series.BorderWidth = 3;
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 8;
            // привязать данные к объекту серии и отобразить диаграмму
            chart1.Series["Series1"].Points.DataBindXY(xValues, yValues);
        }
        void DrawFunction(double x1, double x2, Series series, Equation equation)
        {
            // вычислить значение функции в ряде точек в пределах желаемого диапазона
            int numPoints = 1000;
            double step = (x2 - x1) / numPoints;
            double[] xValues = new double[numPoints + 1];
            double[] yValues = new double[numPoints + 1];
            for (int i = 0; i <= numPoints; i++)
            {
                xValues[i] = x1 + i * step;
                yValues[i] = equation.GetValue(xValues[i]);
            }

            // привязать данные к объекту серии
            series.Points.DataBindXY(xValues, yValues);

            // установить ChartType и XValueType/YValueType properties
            series.ChartType = SeriesChartType.Point;
            series.XValueType = ChartValueType.Double;
            series.YValueType = ChartValueType.Double;

            // настройка внешнего вида и поведения диаграммы и рядаs
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

            comboBox1.Items.Add(new CosEquation(10, 10));
            comboBox1.Items.Add(new SinEquation(10));
            comboBox1.Items.Add(new QuadEquation(10,10,10));
            comboBox1.Items.Add(new ModSinEquation(10));
            comboBox1.Items.Add(new ModSinXEquation(10));
            comboBox1.Items.Add(new CosXEquation(10));
            comboBox1.Items.Add(new SinX(10));
            button1.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            button6.Hide();
            button7.Hide();
            button8.Hide();
            button9.Hide();
            button1.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;


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
            double x1, x2, a1, b1, c1;
            if (!ValidateInputs(textBox1, textBox2, out x1, out x2, out a1, out b1, out c1))
            {
                return;
            }
            double x = double.Parse(textBox1.Text);
            double y = double.Parse(textBox2.Text);           
            // создать новый компонент Chart control
            Chart chart = new Chart();

            // добавьте объект серии на диаграмму
            Series series = new Series();
            chart.Series.Add(series);

            // определите объект уравнения, представляющий функцию, подлежащую построению
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
            double x1, x2, a1, b1, c1;
            if (!ValidateInputs(textBox1, textBox2, out x1, out x2, out a1, out b1, out c1))
            {
                return;
            }
            double x = double.Parse(textBox1.Text);
            double y = double.Parse(textBox2.Text);
            // создать новый компонент Chart control
            Chart chart = new Chart();

            // добавьте объект серии на диаграмму
            Series series = new Series();
            chart.Series.Add(series);

            // определите объект уравнения, представляющий функцию, подлежащую построению
            Equation equation = new QuadEquation(1, 2, 3);
            DrawFunction(x1, x2, series, equation);           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double x1, x2, a1, b1, c1;
            if (!ValidateInputs(textBox1, textBox2, out x1, out x2, out a1, out b1, out c1))
            {
                return;
            }
            double x = double.Parse(textBox1.Text);
            double y = double.Parse(textBox2.Text);
            // создать новый компонент Chart control
            Chart chart = new Chart();

            // добавьте объект серии на диаграмму
            Series series = new Series();
            chart.Series.Add(series);

            // определите объект уравнения, представляющий функцию, подлежащую построению
            Equation equation = new ModSinEquation(2);
            DrawFunction(x1, x2, series, equation);        
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double x1, x2, a1, b1, c1;
            if (!ValidateInputs(textBox1, textBox2, out x1, out x2, out a1, out b1, out c1))
            {
                return;
            }
            double x = double.Parse(textBox1.Text);
            double y = double.Parse(textBox2.Text);
            // создать новый компонент Chart control
            Chart chart = new Chart();

            // добавьте объект серии на диаграмму
            Series series = new Series();
            chart.Series.Add(series);

            // определите объект уравнения, представляющий функцию, подлежащую построению
            Equation equation = new CosEquation(2,2);
            DrawFunction(x1, x2, series, equation);            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double x1, x2, a1, b1, c1;
            if (!ValidateInputs(textBox1, textBox2, out x1, out x2, out a1, out b1, out c1))
            {
                return;
            }
            double x = double.Parse(textBox1.Text);
            double y = double.Parse(textBox2.Text);
            // создать новый компонент Chart control
            Chart chart = new Chart();

            // добавьте объект серии на диаграмму
            Series series = new Series();
            chart.Series.Add(series);

            // определите объект уравнения, представляющий функцию, подлежащую построению
            Equation equation = new ModSinXEquation(2);
            DrawFunction(x1, x2, series, equation);           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            double x1, x2, a1, b1, c1;
            if (!ValidateInputs(textBox1, textBox2, out x1, out x2, out a1, out b1, out c1))
            {
                return;
            }
            double x = double.Parse(textBox1.Text);
            double y = double.Parse(textBox2.Text);
            // создать новый компонент Chart control
            Chart chart = new Chart();

            // добавьте объект серии на диаграмму
            Series series = new Series();
            chart.Series.Add(series);

            // определите объект уравнения, представляющий функцию, подлежащую построению
            Equation equation = new CosXEquation(2);
            DrawFunction(x1, x2, series, equation);            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            double x1, x2, a1, b1, c1;
            if (!ValidateInputs(textBox1, textBox2, out x1, out x2, out a1, out b1, out c1))
            {
                return;
            }
            double x = double.Parse(textBox1.Text);
            double y = double.Parse(textBox2.Text);
            //// создать новый компонент Chart control
            Chart chart = new Chart();

            //// добавьте объект серии на диаграмму
            Series series = new Series();
            chart.Series.Add(series);

            //// определите объект уравнения, представляющий функцию, подлежащую построению
            Equation equation = new SinEquation(1);
            DrawIntegrateFunction(x1, x2, series, equation);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            double x1, x2, a1, b1, c1;
            if (!ValidateInputs(textBox1, textBox2, out x1, out x2, out a1, out b1, out c1))
            {
                return;
            }
            double x = double.Parse(textBox1.Text);
            double y = double.Parse(textBox2.Text);
            //// создать новый компонент Chart control
            Chart chart = new Chart();

            //// добавьте объект серии на диаграмму
            Series series = new Series();
            chart.Series.Add(series);

            //// определите объект уравнения, представляющий функцию, подлежащую построению
            Equation equation = new SinX(1);
            DrawFunction(x1, x2, series, equation);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Laba6v1.SinEquation")
            {
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                label4.Hide();
                label5.Hide();
                textBox4.Hide();
                textBox5.Hide();
                double x1, x2, a1, b1, c1;
                if (!ValidateInputs(textBox1, textBox2, out x1, out x2, out a1, out b1, out c1))
                {
                    return;
                }
                double x = double.Parse(textBox1.Text);
                double y = double.Parse(textBox2.Text);
                double a = double.Parse(textBox3.Text);
                // создать новый компонент Chart control
                Chart chart = new Chart();
                Equation equation = new SinEquation(a);
                RectangleIntegratorv2 integrator = new RectangleIntegratorv2(equation, 0.1);
                // вычислить интегрированную функцию на данном отрезке

                Equation integratedEquation = integrator.Integrate(x1, x2);

                richTextBox1.Text += "Результат интегрирования SinEquation уравнения методом прямоугольников: " + Math.Round(integratedEquation.GetValue(x2), 1) + Environment.NewLine;
                // добавьте объект серии на диаграмму
                Series series = new Series();
                chart.Series.Add(series);
                DrawFunction(x1, x2, series, equation);
               
            }
            else if (comboBox1.SelectedItem.ToString() == "Laba6v1.ModSinEquation") 
            {
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                label4.Hide();
                label5.Hide();
                textBox4.Hide();
                textBox5.Hide();
                double x1, x2, a1, b1, c1;
                if (!ValidateInputs(textBox1, textBox2, out x1, out x2, out a1, out b1, out c1))
                {
                    return;
                }
                double x = double.Parse(textBox1.Text);
                double y = double.Parse(textBox2.Text);
                double a = double.Parse(textBox3.Text);
                // создать новый компонент Chart control
                Chart chart = new Chart();
                Equation equation = new ModSinEquation(a);
                RectangleIntegratorv2 integrator = new RectangleIntegratorv2(equation, 0.1);
                // вычислить интегрированную функцию на данном отрезке

                Equation integratedEquation = integrator.Integrate(x1, x2);

                richTextBox1.Text += "Результат интегрирования ModSinEquation уравнения методом прямоугольников: " + Math.Round(integratedEquation.GetValue(x2), 1) + Environment.NewLine;
                // добавьте объект серии на диаграмму
                Series series = new Series();
                chart.Series.Add(series);
                DrawFunction(x1, x2, series, equation);
            }
            else if (comboBox1.SelectedItem.ToString() == "Laba6v1.ModSinXEquation")
            {
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                label4.Hide();
                label5.Hide();
                textBox4.Hide();
                textBox5.Hide();
                double x1, x2, a1, b1, c1;
                if (!ValidateInputs(textBox1, textBox2, out x1, out x2, out a1, out b1, out c1))
                {
                    return;
                }
                double x = double.Parse(textBox1.Text);
                double y = double.Parse(textBox2.Text);
                double a = double.Parse(textBox3.Text);
                // создать новый компонент Chart control
                Chart chart = new Chart();
                Equation equation = new ModSinXEquation(a);
                RectangleIntegratorv2 integrator = new RectangleIntegratorv2(equation, 0.1);
                // вычислить интегрированную функцию на данном отрезке

                Equation integratedEquation = integrator.Integrate(x1, x2);

                richTextBox1.Text += "Результат интегрирования ModSinXEquation уравнения методом прямоугольников: " + Math.Round(integratedEquation.GetValue(x2), 1) + Environment.NewLine;
                // добавьте объект серии на диаграмму
                Series series = new Series();
                chart.Series.Add(series);
                DrawFunction(x1, x2, series, equation);
            }
            else if (comboBox1.SelectedItem.ToString() == "Laba6v1.CosEquation")
            {
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = false;
                textBox4.Show();
                label4.Show();
                label5.Hide();
                textBox5.Hide();
                double x1, x2, a1, b1, c1;
                if (!ValidateInputs(textBox1, textBox2, out x1, out x2, out a1, out b1, out c1))
                {
                    return;
                }
                double x = double.Parse(textBox1.Text);
                double y = double.Parse(textBox2.Text);
                double a = double.Parse(textBox3.Text);
                double b = double.Parse(textBox4.Text);
                // создать новый компонент Chart control
                Chart chart = new Chart();
                Equation equation = new CosEquation(a, b);
                RectangleIntegratorv2 integrator = new RectangleIntegratorv2(equation, 0.1);
                // вычислить интегрированную функцию на данном отрезке

                Equation integratedEquation = integrator.Integrate(x1, x2);

                richTextBox1.Text += "Результат интегрирования CosEquation уравнения методом прямоугольников: " + Math.Round(integratedEquation.GetValue(x2), 1) + Environment.NewLine;
                // добавьте объект серии на диаграмму
                Series series = new Series();
                chart.Series.Add(series);
                DrawFunction(x1, x2, series, equation);
            }
            else if (comboBox1.SelectedItem.ToString() == "Laba6v1.CosXEquation")
            {
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                label4.Hide();
                label5.Hide();
                textBox4.Hide();
                textBox5.Hide();
                double x1, x2, a1, b1, c1;
                if (!ValidateInputs(textBox1, textBox2, out x1, out x2, out a1, out b1, out c1))
                {
                    return;
                }
                double x = double.Parse(textBox1.Text);
                double y = double.Parse(textBox2.Text);
                double a = double.Parse(textBox3.Text);
                double b = double.Parse(textBox4.Text);
                // создать новый компонент Chart control
                Chart chart = new Chart();
                Equation equation = new CosXEquation(a);
                RectangleIntegratorv2 integrator = new RectangleIntegratorv2(equation, 0.1);
                // вычислить интегрированную функцию на данном отрезке

                Equation integratedEquation = integrator.Integrate(x1, x2);

                richTextBox1.Text += "Результат интегрирования CosXEquation уравнения методом прямоугольников: " + Math.Round(integratedEquation.GetValue(x2), 1) + Environment.NewLine;
                // добавьте объект серии на диаграмму
                Series series = new Series();
                chart.Series.Add(series);
                DrawFunction(x1, x2, series, equation);
            }
            else if (comboBox1.SelectedItem.ToString() == "Laba6v1.SinX")
            {
                textBox3.Enabled = true;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                label4.Hide();
                label5.Hide();
                textBox4.Hide();
                textBox5.Hide();
                double x1, x2, a1, b1, c1;
                if (!ValidateInputs(textBox1, textBox2, out x1, out x2, out a1, out b1, out c1))
                {
                    return;
                }
                double x = double.Parse(textBox1.Text);
                double y = double.Parse(textBox2.Text);
                double a = double.Parse(textBox3.Text);
                // создать новый компонент Chart control
                Chart chart = new Chart();
                Equation equation = new SinX(a);
                RectangleIntegratorv2 integrator = new RectangleIntegratorv2(equation, 0.1);
                // вычислить интегрированную функцию на данном отрезке

                Equation integratedEquation = integrator.Integrate(x1, x2);

                richTextBox1.Text += "Результат интегрирования SinX уравнения методом прямоугольников: " + Math.Round(integratedEquation.GetValue(x2), 1) + Environment.NewLine;
                // добавьте объект серии на диаграмму
                Series series = new Series();
                chart.Series.Add(series);
                DrawFunction(x1, x2, series, equation);
            }
            else if (comboBox1.SelectedItem.ToString() == "Laba6v1.QuadEquation")
            {
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                label4.Show();
                label5.Show();
                textBox4.Show();
                textBox5.Show();
                double x1, x2, a1, b1, c1;
                if (!ValidateInputs(textBox1, textBox2, out x1, out x2, out a1, out b1, out c1))
                {
                    return;
                }
                double x = double.Parse(textBox1.Text);
                double y = double.Parse(textBox2.Text);
                double a = double.Parse(textBox3.Text);
                double b = double.Parse(textBox4.Text);
                double c = double.Parse(textBox5.Text);
                // создать новый компонент Chart control
                Chart chart = new Chart();
                Equation equation = new QuadEquation(a, b, c);
                RectangleIntegratorv2 integrator = new RectangleIntegratorv2(equation, 0.1);
                // вычислить интегрированную функцию на данном отрезке

                Equation integratedEquation = integrator.Integrate(x1, x2);               
                richTextBox1.Text += "Результат интегрирования квадратного уравнения методом прямоугольников: " + Math.Round(integratedEquation.GetValue(x2), 1) + Environment.NewLine;
                // добавьте объект серии на диаграмму
                Series series = new Series();
                chart.Series.Add(series);
                DrawFunction(x1, x2, series, equation);
            }
        }
    }
}
