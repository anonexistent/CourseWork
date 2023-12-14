using OxyPlot;
using OxyPlot.Series;
using System.Windows;
using NCalc;
//  the best making clear
using Expression = NCalc.Expression;
using System;
using System.Windows.Input;

public delegate double Del(double x);

namespace CourseWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        //  without auto-prop NOT WORK!!
        public PlotModel PlotModel { get; set; } = new();

        public MainWindow()
        {
            InitializeComponent();
            InitChart();
            DataContext = this;
        }

        //  x0y0 axis paint
        private void InitChart()
        {
            PlotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Bottom,
                ExtraGridlineColor = OxyPlot.OxyColors.Black,
                ExtraGridlineThickness = 2,
                ExtraGridlines = new double[] { 0 }
            });

            PlotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Left,
                ExtraGridlineColor = OxyPlot.OxyColors.Black,
                ExtraGridlineThickness = 2,
                ExtraGridlines = new double[] { 0 }
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            #region +zero

            //string functionText = txtFunction.Text;

            //LineSeries lineSeries = new();
            //lineSeries.Color = OxyColors.Blue;

            //for (double x = -10; x <= 10; x += 0.1)
            //{
            //    double y = EvaluateFunction(functionText, x);
            //    lineSeries.Points.Add(new(x, y));
            //}

            //PlotModel.Series.Clear();
            //PlotModel.Series.Add(lineSeries);
            //PlotModel.InvalidatePlot(true);

            #endregion

            #region -zero

            //string functionText = txtFunction.Text;
            //LineSeries lineSeries = new LineSeries();
            //lineSeries.Color = OxyColors.Blue;

            //for (double x = -10; x <= 10; x += 0.1)
            //{
            //    if (x != 0) // Исключаем точку x=0 из графика
            //    {
            //        double y = EvaluateFunction(functionText, x);
            //        lineSeries.Points.Add(new DataPoint(x, y));
            //    }
            //}

            //PlotModel.Series.Clear();
            //PlotModel.Series.Add(lineSeries);
            //PlotModel.InvalidatePlot(true);

            #endregion

            #region +-zero

            this.Cursor = Cursors.Wait;

            string functionText = txtFunction.Text;
            LineSeries lineSeries = new LineSeries();
            lineSeries.Color = OxyColors.Blue;

            for (double x = -25; x <= -0.1; x += 0.1)
            {
                try
                {
                    double y = EvaluateFunction(functionText, x);
                    lineSeries.Points.Add(new DataPoint(x, y));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    break;
                }
            }

            for (double x = 0.1; x <= 25; x += 0.1)
            {
                try
                {
                    double y = EvaluateFunction(functionText, x);
                    lineSeries.Points.Add(new DataPoint(x, y));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    break;
                }
            }

            PlotModel.Series.Clear();
            PlotModel.Series.Add(lineSeries);
            PlotModel.InvalidatePlot(true);

            this.Cursor = Cursors.Arrow;

            #endregion
        }

        //  get points
        /// <summary>
        ///1. Trigonometric functions:
        /// - sin(x)
        /// - cos(x)
        /// - tan(x)
        /// - asin(x)
        /// - acos(x)
        /// - atan(x)
        ///
        ///2. Logarithmic functions:
        /// - log(x)
        /// - log10(x)
        ///
        ///3. Arithmetic functions:
        /// - abs(x)
        /// - sqrt(x)
        /// - pow(x, y)
        ///
        ///4. Statistical functions:
        /// - min(x, y)
        /// - max(x, y)
        /// - avg(x, y, ...)
        /// - sum(x, y, ...)
        ///
        ///5. Other:
        /// - exp(x)
        /// - round(x)
        /// - sign(x)
        ///         
        /// /// </summary>
        /// <param name="functionText">user input</param>
        /// <param name="x">value</param>
        /// <returns>a point ex for chart</returns>
        private double EvaluateFunction(string functionText, double x)
        {
            double result = double.PositiveInfinity;
            try
            {
                Expression expression = new Expression(functionText);
                expression.Parameters["x"] = x;
                var a = expression.Evaluate();
                result = Convert.ToDouble(a);
            }
            catch (Exception)
            {

            }

            return result;
        }

        private double ParseFunction(string functionText, double x)
        {
            NCalc.Expression expression = new(functionText);
            expression.Parameters["x"] = x;
            double result = (double)expression.Evaluate();
            return result;
        }
    }
}
