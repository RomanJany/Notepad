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
                MessageBoxResult result = MessageBox.Show("Save changes?",
                                                          "Unsaved changes",
                                                          MessageBoxButton.YesNoCancel,
                                                          MessageBoxImage.None,
                                                          MessageBoxResult.Cancel);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        _mainViewModel.saveFileCommand.Execute(null);
                        if (_mainViewModel.FileSaved)
                        {
                            Application.Current.Shutdown();
                        }
                        break;

                    case MessageBoxResult.No:
                        Application.Current.Shutdown();
                        break;

                    case MessageBoxResult.Cancel:
                        break;
                }
            }
            else
            {
                Application.Current.Shutdown();
            }
        }
    }
}
