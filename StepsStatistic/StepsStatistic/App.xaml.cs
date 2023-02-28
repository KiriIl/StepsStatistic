using StepsStatistic.ViewModels;
using StepsStatistic.Views;
using System.Windows;

namespace StepsStatistic
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            StatisticViewModel statisticViewModel = new StatisticViewModel();
            MainWindow = new StatisticWindow(statisticViewModel);
            MainWindow.Show();
        }
    }
}