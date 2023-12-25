using System.Windows;

namespace CourseWork
{
    /// <summary>
    /// StartWindow.xaml welcome
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow() => InitializeComponent();

        private void Button_Click(object sender, RoutedEventArgs e) => this.Close();

        private void Window_Closing(object sender, 
            System.ComponentModel.CancelEventArgs e)
        {
            gMain.Children.Clear();

            MainWindow win = new();
            win.Show();
        }
    }
}
