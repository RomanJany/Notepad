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
            if (_mainViewModel.Text.Contains(_mainViewModel.FindText))
            {
                int findIndex = _mainViewModel.Text.Length;
                string text = _mainViewModel.Text;
                bool found = false;

                // Search for string before CaretIndex
                while (text.Contains(_mainViewModel.FindText))
                {
                    int currentIndex = text.LastIndexOf(_mainViewModel.FindText);
                    text = text.Substring(0, currentIndex);

                    // Found previous occurence
                    if (currentIndex < _mainViewModel.CaretIndex)
                    {
                        findIndex = currentIndex;
                        found = true;
                        break;
                    }
                    // Else continue
                    else
                    {
                        findIndex = currentIndex;
                    }
                }

                // If the previous occurence wasn't found -> select last occurence
                if (!found)
                {
                    findIndex = _mainViewModel.Text.LastIndexOf(_mainViewModel.FindText);
                }   

                // Set the new index
                _mainViewModel.CaretIndex = findIndex;
            }
        }

        private void ReplacePrevious()
        {
            throw new NotImplementedException();
        }
    }
}
