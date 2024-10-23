using Notepad.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.Commands
{
    public class SettingsOpenCommand : BaseCommand
    {
        private MainViewModel _mainViewModel;
        public SettingsOpenCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object? parameter)
        {
            _mainViewModel.SettingsOpen = true;
        }
    }
}
