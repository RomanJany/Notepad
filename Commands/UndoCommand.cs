using Notepad.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.Commands
{
    public class UndoCommand : BaseCommand
    {
        private readonly MainViewModel _mainViewModel;
        
        public UndoCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object? parameter)
        {
            _mainViewModel.TextHistory.Pop();
            _mainViewModel.textFile.Text = _mainViewModel.TextHistory.Peek();
        }

        public override bool CanExecute(object? parameter)
        {
            return _mainViewModel.TextHistory.CanPop;
        }
    }
}
