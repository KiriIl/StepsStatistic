using Microsoft.Win32;
using StepsStatistic.Services.Abstraction;
using StepsStatistic.Utils;
using System.Linq;

namespace StepsStatistic.Services
{
    public class DialogService : IDialogService
    {
        private FilePath _fileToSave;
        private FilePath[] _filesToOpen;

        public FilePath FileToSave => _fileToSave;
        public FilePath[] FilesToOpen => _filesToOpen;

        public bool OpenFilesDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == true)
            {
                _filesToOpen = openFileDialog.FileNames.Select(x => new FilePath(x)).ToArray();
                return true;
            }

            return false;
        }

        public bool SaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                _fileToSave = new FilePath(saveFileDialog.FileName);
                return true;
            }

            return false;
        }
    }
}