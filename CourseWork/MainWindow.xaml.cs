using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CourseWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public PlotModel Model1 { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Model1 = Cc();
            //Model1.Series.Add(new FunctionSeries(Math.Pow, -10f, 10f, 0.25f, "text f 1"));

            pvMain.DataContext = this;
        }

        PlotModel Aa()
        {
            var model = new PlotModel { Title = "Fun with Bats" };

            Func<double, double> batFn1 = (x) => 2 * Math.Sqrt(-Math.Abs(Math.Abs(x) - 1) * Math.Abs(3 - Math.Abs(x)) / ((Math.Abs(x) - 1) * (3 - Math.Abs(x)))) * (1 + Math.Abs(Math.Abs(x) - 3) / (Math.Abs(x) - 3)) * Math.Sqrt(1 - Math.Pow((x / 7), 2)) + (5 + 0.97 * (Math.Abs(x - 0.5) + Math.Abs(x + 0.5)) - 3 * (Math.Abs(x - 0.75) + Math.Abs(x + 0.75))) * (1 + Math.Abs(1 - Math.Abs(x)) / (1 - Math.Abs(x)));
            Func<double, double> batFn2 = (x) => -3 * Math.Sqrt(1 - Math.Pow((x / 7), 2)) * Math.Sqrt(Math.Abs(Math.Abs(x) - 4) / (Math.Abs(x) - 4));
            Func<double, double> batFn3 = (x) => Math.Abs(x / 2) - 0.0913722 * (Math.Pow(x, 2)) - 3 + Math.Sqrt(1 - Math.Pow((Math.Abs(Math.Abs(x) - 2) - 1), 2));
            Func<double, double> batFn4 = (x) => (2.71052 + (1.5 - .5 * Math.Abs(x)) - 1.35526 * Math.Sqrt(4 - Math.Pow((Math.Abs(x) - 1), 2))) * Math.Sqrt(Math.Abs(Math.Abs(x) - 1) / (Math.Abs(x) - 1)) + 0.9;

            model.Series.Add(new FunctionSeries(batFn1, -8, 8, 0.0001));
            model.Series.Add(new FunctionSeries(batFn2, -8, 8, 0.0001));
            model.Series.Add(new FunctionSeries(batFn3, -8, 8, 0.0001));
            model.Series.Add(new FunctionSeries(batFn4, -8, 8, 0.0001));

            model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, MaximumPadding = 0.1, MinimumPadding = 0.1 });
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, MaximumPadding = 0.1, MinimumPadding = 0.1 });

            return model;
        }

        PlotModel Bb()
        {
            var model = new PlotModel { Title = "ScatterSeries" };
            var scatterSeries = new ScatterSeries { MarkerType = MarkerType.Circle };
            Random uuu = new Random(314);
            for (int i = 0; i < 100; i++)
            {
                var x = uuu.NextDouble();
                var y = uuu.NextDouble();
                var size = uuu.Next(5, 15);
                var colorValue = uuu.Next(100, 1000);
                scatterSeries.Points.Add(new ScatterPoint(x, y, size, colorValue));
            }

            model.Series.Add(scatterSeries);
            model.Axes.Add(new LinearColorAxis { Position = AxisPosition.Right, Palette = OxyPalettes.Jet(200) });

            return model;
        }

        PlotModel Cc()
        {
            var model = new PlotModel() { Title = "test points 1" };



            return model;
        }

    }
}
