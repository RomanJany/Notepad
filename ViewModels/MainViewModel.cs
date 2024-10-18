using Notepad.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private NotepadSettings notepadSettings;
        private TextFile textFile;

        public MainViewModel()
        {
            notepadSettings = new NotepadSettings("settings.json");
            textFile = new TextFile();
        }
    }
}
