using Notepad.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Notepad.Commands
{
    public class SaveOnExitCommand : BaseCommand
    {
        private MainViewModel _mainViewModel;
        public SaveOnExitCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object? parameter)
        {
            _mainViewModel.ConfirmExitPopup = false;
            _mainViewModel.saveFileCommand.Execute(null);
            if (_mainViewModel.FileSaved)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
