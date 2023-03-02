using StepsStatistic.Commands;
using StepsStatistic.Models;
using StepsStatistic.Services.Abstraction;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace StepsStatistic.ViewModels
{
    public class StatisticViewModel : BaseViewModel
    {
        private ObservableCollection<UserModel> _users;
        private UserModel _selectedUser;

        public ICommand OpenFilesCommand { get; }
        public ICommand SaveFileCommand { get; }
        public ChartViewModel ChartViewModel { get; }
        public ObservableCollection<UserModel> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }
        public UserModel SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                OnSelectedUserChanged?.Invoke(_selectedUser);
                OnPropertyChanged();
            }
        }

        public event Action<UserModel> OnSelectedUserChanged;

        public StatisticViewModel(
            IDialogService dialogService,
            ISerializerService<UserModel> serializer,
            ChartViewModel chartViewModel)
        {
            _users = new ObservableCollection<UserModel>();
            OpenFilesCommand = new OpenFilesCommand(this, dialogService, serializer);
            SaveFileCommand = new SaveFileCommand(dialogService, serializer);
            ChartViewModel = chartViewModel;
            OnSelectedUserChanged += ChartViewModel.UpdateChart;
        }
    }
}