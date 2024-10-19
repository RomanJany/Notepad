using Microsoft.Win32;
using Notepad.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.Commands
{
    public class SaveFileCommand : BaseCommand
    {
        private readonly MainViewModel _mainViewModel;

        public SaveFileCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object? parameter)
        {
            if (_mainViewModel.FilePath == "")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == true)
                {
                    _mainViewModel.textFile.SaveFile(saveFileDialog.FileName);
                }
            }
            else
            {
                _mainViewModel.textFile.SaveFile();
            }

            _mainViewModel.textFile = _mainViewModel.textFile;
        }
    }
}
