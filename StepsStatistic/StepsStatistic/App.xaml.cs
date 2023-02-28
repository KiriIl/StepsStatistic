using StepsStatistic.Views;
using System.Windows;

namespace StepsStatistic
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow = new StatisticWindow();
            MainWindow.Show();
        }
    }
}