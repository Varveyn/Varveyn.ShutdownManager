using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace Varveyn.ShutdownManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var licenseKey = File.ReadAllText("syncfusion-license.txt");
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(licenseKey);

            InitializeComponent();

            this.preselectedValuesPicker.ValueChanged += HandlePreselectedValueChange;
            this.scheduleButton.Click += HandleScheduleClick;
        }

        private void HandleScheduleClick(object sender, RoutedEventArgs e)
        {
            var span = this.shutdownTimespanEdit.Value;

            var shutdownDelayInSeconds = span?.TotalSeconds ?? 1200;

            Process.Start("shutdown", $"/s /t {shutdownDelayInSeconds}");
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
