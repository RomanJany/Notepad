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
            if (_mainViewModel.Text.Contains(_mainViewModel.FindText))
            {
                int findIndex = 0;
                string text = _mainViewModel.Text;
                bool found = false;

                // Search for string after CaretIndex
                while (text.Contains(_mainViewModel.FindText))
                {
                    int currentIndex = text.IndexOf(_mainViewModel.FindText);
                    text = text.Substring(currentIndex + 1);

                    // Found next occurence
                    if ((findIndex + currentIndex) > _mainViewModel.CaretIndex)
                    {
                        findIndex += currentIndex;
                        found = true;
                        break;
                    }
                    // Else continue
                    else
                    {
                        findIndex += currentIndex + 1;
                    }
                }

                // If the next occurence wasn't found -> select first occurence
                if (!found)
                {
                    findIndex = _mainViewModel.Text.IndexOf(_mainViewModel.FindText);
                }   

                // Set the new index
                _mainViewModel.CaretIndex = findIndex;
            }
        }

        private void ReplaceNext()
        {
            throw new NotImplementedException();
        }
    }
}
