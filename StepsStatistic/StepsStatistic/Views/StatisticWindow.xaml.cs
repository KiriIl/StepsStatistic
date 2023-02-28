using System.Windows;

namespace StepsStatistic.Views
{
    public partial class StatisticWindow : Window
    {
        public StatisticWindow(object dataContext)
        {
            InitializeComponent();

            DataContext = dataContext;
        }
    }
}