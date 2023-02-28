using StepsStatistic.Utils;

namespace StepsStatistic.Services.Abstraction
{
    public interface IDialogService
    {
        FilePath FileToSave { get; }
        FilePath[] FilesToOpen { get; }
        bool OpenFilesDialog();
        bool SaveFileDialog();
    }
}