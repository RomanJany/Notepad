using Notepad.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Notepad.Commands
{
    public class FindPreviousCommand : BaseCommand
    {
        private MainViewModel _mainViewModel;
        public FindPreviousCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object? parameter)
        {
            if (_mainViewModel.FindText == "") { return; }
            if (_mainViewModel.ReplaceVisibility == Visibility.Collapsed)
            {
                FindPrevious();
            }
            else
            {
                ReplacePrevious();
            }
        }

        private void FindPrevious()
        {
            throw new NotImplementedException();
        }

        private void ReplacePrevious()
        {
            throw new NotImplementedException();
        }
    }
}
