using Notepad.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Notepad.Commands
{
    public class ExitWithoutSavingCommand : BaseCommand
    {
        private MainViewModel _mainViewModel;
        public ExitWithoutSavingCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object? parameter)
        {
            Application.Current.Shutdown();
        }
    }
}
