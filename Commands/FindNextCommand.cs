using Notepad.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Notepad.Commands
{
    public class FindNextCommand : BaseCommand
    {
        private MainViewModel _mainViewModel;
        public FindNextCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object? parameter)
        {
            if (_mainViewModel.FindText == "") { return; }
            if (_mainViewModel.ReplaceVisibility == Visibility.Collapsed)
            {
                FindNext();
            }
            else
            {
                ReplaceNext();
            }
        }

        private void FindNext()
        {
            throw new NotImplementedException();
        }

        private void ReplaceNext()
        {
            throw new NotImplementedException();
        }
    }
}
