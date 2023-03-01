using StepsStatistic.Models;
using StepsStatistic.Services.Abstraction;
using System.Threading.Tasks;

namespace StepsStatistic.Commands
{
    public class SaveFileCommand : BaseAsyncCommand
    {
        private readonly IDialogService _dialogService;
        private readonly ISerializerService<UserModel> _serializer;

        public SaveFileCommand(
            IDialogService dialogService,
            ISerializerService<UserModel> serializer)
        {
            _dialogService = dialogService;
            _serializer = serializer;
        }

        public override bool CanExecute(object parameter)
        {
            var model = parameter as UserModel;
            return model != null && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (_dialogService.SaveFileDialog())
            {
                var model = parameter as UserModel;
                await _serializer.SerializeAsync(_dialogService.FileToSave, model);
            }
        }
    }
}