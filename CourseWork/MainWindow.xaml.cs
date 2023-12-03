using OxyPlot;
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

            Model1 = new PlotModel() { Title = "test 1" };
            Model1.Series.Add(new FunctionSeries(Math.Sqrt, 0, 25.1f, 0.1, "text f 1"));

            pvMain.DataContext = this;
        }
    }
}
