using Microsoft.Win32;
using Notepad.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.Commands
{
    public class SaveAsFileCommand : BaseCommand
    {
        private readonly MainViewModel _mainViewModel;

        public SaveAsFileCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object? parameter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == true)
            {
                _mainViewModel.textFile.SaveFile(saveFileDialog.FileName);
            }

            _mainViewModel.textFile = _mainViewModel.textFile;
        }
    }
}
