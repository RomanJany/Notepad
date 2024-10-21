using Notepad.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.Commands
{
    public class RedoCommand : BaseCommand
    {
        private readonly MainViewModel _mainViewModel;

        public RedoCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object? parameter)
        {
            _mainViewModel.textFile.Text = _mainViewModel.TextHistory.Back();

            OnCanExecuteChanged();
            ((UndoCommand)_mainViewModel.undoCommand).OnCanExecuteChanged();
            _mainViewModel.OnPropertyChanged(nameof(_mainViewModel.Text));
        }

        public override bool CanExecute(object? parameter)
        {
            return _mainViewModel.TextHistory.CanGoBack;
        }
    }
}
