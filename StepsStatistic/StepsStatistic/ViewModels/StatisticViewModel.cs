using StepsStatistic.Models;
using System.Collections.ObjectModel;

namespace StepsStatistic.ViewModels
{
    public class StatisticViewModel : BaseViewModel
    {
        private ObservableCollection<UserModel> _users;

        public ObservableCollection<UserModel> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        public StatisticViewModel()
        {
            _users = new ObservableCollection<UserModel>();
        }
    }
}