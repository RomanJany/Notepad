using Notepad.Model;
using Notepad.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.Commands
{
    public class NewFileCommand : BaseCommand
    {
        private readonly MainViewModel _mainViewModel;

        public NewFileCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object? parameter)
        {
            _mainViewModel.textFile = new TextFile();
        }
    }
}
