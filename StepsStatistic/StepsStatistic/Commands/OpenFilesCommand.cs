using StepsStatistic.Models;
using StepsStatistic.Services.Abstraction;
using StepsStatistic.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace StepsStatistic.Commands
{
    public class OpenFilesCommand : BaseAsyncCommand
    {
        private readonly StatisticViewModel _statisticViewModel;
        private readonly IDialogService _dialogService;
        private readonly ISerializerService<UserModel> _serializer;

        public OpenFilesCommand(
            StatisticViewModel statisticViewModel,
            IDialogService dialogService,
            ISerializerService<UserModel> serializer)
        {
            _statisticViewModel = statisticViewModel;
            _dialogService = dialogService;
            _serializer = serializer;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (_dialogService.OpenFilesDialog())
            {
                IEnumerable<UserModel> models = new List<UserModel>();

                foreach (var filePath in _dialogService.FilesToOpen)
                {
                    var deserializedModels = await _serializer.DeserializeAsync(filePath);
                    if (deserializedModels.Count() > 0)
                    {
                        models = models.Union(deserializedModels);
                    }
                }

                var users = models
                    .GroupBy(userModel => userModel.User)
                    .Select(groupedUserModel => new UserModel
                    {
                        User = groupedUserModel.Key,
                        Stats = groupedUserModel.SelectMany(userModel => userModel.Stats).ToList()
                    });

                _statisticViewModel.Users = new ObservableCollection<UserModel>(users);
            }
        }
    }
}