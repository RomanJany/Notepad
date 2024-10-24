using Notepad.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Notepad.Commands
{
    public class ExitCommand : BaseCommand
    {
        private MainViewModel _mainViewModel;
        public ExitCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object? parameter)
        {
            if (!_mainViewModel.FileSaved)
            {
                _mainViewModel.ConfirmExit();
            }
            else
            {
                Application.Current.Shutdown();
            }
        }
    }
}
