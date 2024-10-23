using Notepad.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.Commands
{
    public class SettingsCloseCommand : BaseCommand
    {
        private MainViewModel _mainViewModel;
        public SettingsCloseCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object? parameter)
        {
            _mainViewModel.SettingsOpen = false;
        }
    }
}
