﻿using Notepad.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.Commands
{
    public class SetFontSizeCommand : BaseCommand
    {
        private readonly MainViewModel _mainViewModel;

        public SetFontSizeCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object? parameter)
        {
            if (parameter != null)
            {
                _mainViewModel.FontSize = (double)parameter;
            }
        }
    }
}
