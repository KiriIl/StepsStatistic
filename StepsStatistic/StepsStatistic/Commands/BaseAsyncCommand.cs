using System.Threading.Tasks;

namespace StepsStatistic.Commands
{
    public abstract class BaseAsyncCommand : BaseCommand
    {
        public bool IsExecuting { get; set; }

        public override bool CanExecute(object parameter)
        {
            return !IsExecuting;
        }

        public override sealed async void Execute(object parameter)
        {
            IsExecuting = true;
            await ExecuteAsync(parameter);
            IsExecuting = false;
        }

        public abstract Task ExecuteAsync(object parameter);
    }
}