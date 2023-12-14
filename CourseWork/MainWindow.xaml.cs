using OxyPlot;
using OxyPlot.Series;
using System.Windows;
using NCalc;
//  the best making clear
using Expression = NCalc.Expression;
using System;

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

            string functionText = txtFunction.Text;
            LineSeries lineSeries = new LineSeries();
            lineSeries.Color = OxyColors.Blue;

            for (double x = -10; x <= -0.1; x += 0.1)
            {
                double y = EvaluateFunction(functionText, x);
                lineSeries.Points.Add(new DataPoint(x, y));
            }

            for (double x = 0.1; x <= 10; x += 0.1)
            {
                double y = EvaluateFunction(functionText, x);
                lineSeries.Points.Add(new DataPoint(x, y));
            }

            PlotModel.Series.Clear();
            PlotModel.Series.Add(lineSeries);
            PlotModel.InvalidatePlot(true);

            #endregion
        }

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
        /// </summary>
        /// <param name="functionText"></param>
        /// <param name="x"></param>
        /// <returns></returns>

        private double EvaluateFunction(string functionText, double x)
        {
            Expression expression = new Expression(functionText);
            expression.Parameters["x"] = x;
            var a = expression.Evaluate();
            double result = Convert.ToDouble(a);
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

    #region v 1

//    public partial class MainWindow : Window
    //    {
    //        public PlotModel Model1 { get; set; } = new();
    //        org.mariuszgromada.math.mxparser.Expression ex = new();

    //        private static string begin = @"using System;
    //namespace CourseWork
    //{
    //    public delegate double Del(double x);
    //    public static class LambdaCreator 
    //    {
    //        public static Del Create()
    //        {
    //            return (x)=>";
    //        private static string end = @";
    //        }
    //    }
    //}";

    //        public MainWindow()
    //        {
    //            InitializeComponent();

    //            Model1 = Dd(); // Используйте метод Aa() для инициализации начальной модели
    //            pvMain.DataContext = this;

    //            ex = new org.mariuszgromada.math.mxparser.Expression(); // Создаем экземпляр ex
    //            //Model1.Series.Add(new FunctionSeries(Math.Pow, -10f, 10f, 0.25f, "text f 1"));

    //            pvMain.DataContext = this;
    //        }

    //        PlotModel Aa()
    //        {
    //            var model = new PlotModel { Title = "Fun with Bats" };

    //            Func<double, double> batFn1 = (x) => 2 * Math.Sqrt(-Math.Abs(Math.Abs(x) - 1) * Math.Abs(3 - Math.Abs(x)) / ((Math.Abs(x) - 1) * (3 - Math.Abs(x)))) * (1 + Math.Abs(Math.Abs(x) - 3) / (Math.Abs(x) - 3)) * Math.Sqrt(1 - Math.Pow((x / 7), 2)) + (5 + 0.97 * (Math.Abs(x - 0.5) + Math.Abs(x + 0.5)) - 3 * (Math.Abs(x - 0.75) + Math.Abs(x + 0.75))) * (1 + Math.Abs(1 - Math.Abs(x)) / (1 - Math.Abs(x)));
    //            Func<double, double> batFn2 = (x) => -3 * Math.Sqrt(1 - Math.Pow((x / 7), 2)) * Math.Sqrt(Math.Abs(Math.Abs(x) - 4) / (Math.Abs(x) - 4));
    //            Func<double, double> batFn3 = (x) => Math.Abs(x / 2) - 0.0913722 * (Math.Pow(x, 2)) - 3 + Math.Sqrt(1 - Math.Pow((Math.Abs(Math.Abs(x) - 2) - 1), 2));
    //            Func<double, double> batFn4 = (x) => (2.71052 + (1.5 - .5 * Math.Abs(x)) - 1.35526 * Math.Sqrt(4 - Math.Pow((Math.Abs(x) - 1), 2))) * Math.Sqrt(Math.Abs(Math.Abs(x) - 1) / (Math.Abs(x) - 1)) + 0.9;

    //            model.Series.Add(new FunctionSeries(batFn1, -8, 8, 0.0001));
    //            model.Series.Add(new FunctionSeries(batFn2, -8, 8, 0.0001));
    //            model.Series.Add(new FunctionSeries(batFn3, -8, 8, 0.0001));
    //            model.Series.Add(new FunctionSeries(batFn4, -8, 8, 0.0001));

    //            model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, MaximumPadding = 0.1, MinimumPadding = 0.1 });
    //            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, MaximumPadding = 0.1, MinimumPadding = 0.1 });

    //            return model;
    //        }

    //        PlotModel Bb()
    //        {
    //            var model = new PlotModel { Title = "ScatterSeries" };
    //            var scatterSeries = new ScatterSeries { MarkerType = MarkerType.Circle };
    //            Random uuu = new Random(314);
    //            for (int i = 0; i < 100; i++)
    //            {
    //                var x = uuu.NextDouble();
    //                var y = uuu.NextDouble();
    //                var size = uuu.Next(5, 15);
    //                var colorValue = uuu.Next(100, 1000);
    //                scatterSeries.Points.Add(new ScatterPoint(x, y, size, colorValue));
    //            }

    //            model.Series.Add(scatterSeries);
    //            model.Axes.Add(new LinearColorAxis { Position = AxisPosition.Right, Palette = OxyPalettes.Jet(200) });

    //            return model;
    //        }

    //        PlotModel Cc()
    //        {
    //            var model = new PlotModel() { Title = "test points 1" };

    //            var series = new LineSeries();
    //            for (double x = -150; x <= 150; x += 0.1)
    //            {
    //                ex.setArgumentValue("qx", x);
    //                double y = ex.calculate();
    //                series.Points.Add(new DataPoint(x, y));
    //            }
    //             model.Series.Add(series);

    //            return model;
    //        }

    //        PlotModel Dd()
    //        {
    //            PlotModel model = new PlotModel() { Title = "test points 1" };

    //            string functionText = tbFunc.Text;
    //            FunctionSeries functionSeries = new FunctionSeries(x => EvaluateFunction(x, functionText), -10, 10, 0.1f, title: functionText);
    //            Model1.Series.Clear();
    //            Model1.Series.Add(functionSeries);
    //            Model1.InvalidatePlot(true);

    //            return Model1;
    //        }

    //        private void tbFunc_KeyDown(object sender, KeyEventArgs e)
    //        {
    //            if (e.Key == Key.Enter)
    //            {

    //                UpdateModelWithFunction(tbFunc.Text); // Вызываем метод для обновления модели с новой функцией
    //            }

    //        }

    //        private void UpdateModelWithFunction(string functionText)
    //        {
    //            FunctionSeries functionSeries = new FunctionSeries(x => EvaluateFunction(x, functionText), -10, 10, 0.1f, title: functionText);
    //            Model1.Series.Clear();
    //            Model1.Series.Add(functionSeries);
    //            Model1.InvalidatePlot(true);
    //        }

    //        private void UpdateModelWithFunction2(string functionText)
    //        {
    //            FunctionSeries functionSeries = new FunctionSeries(x => EvaluateFunction(functionText, x), -10, 10, 1, title: functionText);
    //            Model1.Series.Clear();
    //            Model1.Series.Add(functionSeries);
    //            Model1.InvalidatePlot(true);
    //        }

    //        private double EvaluateFunction(double x, string function)
    //        {
    //            double result = 0;
    //            try
    //            {
    //                ex.setExpressionString(function);
    //                ex.defineArgument("x", x);
    //                result = ex.calculate();
    //            }
    //            catch (Exception ex)
    //            {
    //                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
    //            }
    //            return result;
    //        }

    //        private void btnGet_Click(object sender, RoutedEventArgs e)
    //        {
    //            //var a = this.EvaluateFunction(tbFunc.Text, 3f);
    //            //MessageBox.Show("f(3)= " + a.ToString());

    //            //UpdateModelWithFunction2(tbFunc.Text);

    //            //Model1 = new();

    //            ScatterSeries vs = new();
    //            for (int i = -1000; i < 1000; i++)
    //            {
    //                ScatterErrorPoint a = new(i, EvaluateFunction(tbFunc.Text, i), 0, 0);
    //                vs.Points.Add(a);
    //                //vs.Points.Add(EvaluateFunction(tbFunc.Text,i));
    //            }
    //            Model1.Series.Add(vs);

    //            //Model1.Axes.Clear();

    //            Model1.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, MaximumPadding = 0.1, MinimumPadding = 0.1 });
    //            Model1.Axes.Add(new LinearAxis { Position = AxisPosition.Left, MaximumPadding = 0.1, MinimumPadding = 0.1 });

    //            pvMain.DataContext = this;

    //        }

    //        private void btnGet_Click2(object sender, RoutedEventArgs e)
    //        {
    //            string middle = tbFunc.Text;
    //            CSharpCodeProvider provider = new CSharpCodeProvider();
    //            CompilerParameters parameters = new CompilerParameters();
    //            parameters.GenerateInMemory = true;
    //            parameters.ReferencedAssemblies.Add("System.dll");
    //            CompilerResults results = provider.CompileAssemblyFromSource(parameters, begin + middle + end);
    //            var cls = results.CompiledAssembly.GetType("MyNamespace.LambdaCreator");
    //            var method = cls.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);
    //            var del = (method.Invoke(null, null) as Delegate);
    //            MessageBox.Show(del.DynamicInvoke(5).ToString());
    //        }

    //        public double EvaluateFunction(string functionText, double xValue)
    //        {
    //            org.mariuszgromada.math.mxparser.Expression expression = new(functionText, new Argument("x=" + xValue));
    //            return expression.calculate();
    //        }
    //    }
    #endregion
}
