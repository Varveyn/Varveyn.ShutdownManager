using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Varveyn.ShutdownManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.preselectedValuesPicker.ValueChanged += HandlePreselectedValueChange;
            this.scheduleButton.Click += HandleScheduleClick;
        }

        private void HandleScheduleClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Scheduled!");
        }

        private void HandlePreselectedValueChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var span = GetPreselectedValue((int)e.NewValue);

            this.shutdownTimespanEdit.Dispatcher.Invoke(() =>
            {
                this.shutdownTimespanEdit.Value = span;
            });
        }

        private static TimeSpan GetPreselectedValue(int value) => value switch
        {
            1 => TimeSpan.FromMinutes(5),
            2 => TimeSpan.FromMinutes(10),
            3 => TimeSpan.FromMinutes(20),
            4 => TimeSpan.FromMinutes(30),
            5 => TimeSpan.FromMinutes(40),
            _ => TimeSpan.FromMinutes(20),
        };
    }
}
