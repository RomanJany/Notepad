using Notepad.Commands;
using Notepad.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace Notepad.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            notepadSettings = new NotepadSettings("settings.json");
            textFile = new TextFile();

            newFileCommand = new NewFileCommand(this);
            openFileCommand = new OpenFileCommand(this);
            saveFileCommand = new SaveFileCommand(this);
        }

        private NotepadSettings _notepadSettings;
        public NotepadSettings notepadSettings 
        { 
            get
            {
                return _notepadSettings;
            }
            set
            {
                _notepadSettings = value;
                OnPropertyChanged(nameof(notepadSettings));
                OnPropertyChanged(nameof(Theme));
                OnPropertyChanged(nameof(FontSize));
                OnPropertyChanged(nameof(Font));
            }
        }

        private TextFile _textFile;
        public TextFile textFile 
        { 
            get
            {
                return _textFile;
            }
            set
            {
                _textFile = value;
                OnPropertyChanged(nameof(textFile));
                OnPropertyChanged(nameof(Text));
            }
        }


        public NotepadSettings.NotepadTheme Theme
        {
            get
            {
                return notepadSettings.Theme;
            }
            set
            {
                notepadSettings.Theme = value;
                OnPropertyChanged(nameof(Theme));
            }
        }

        public double FontSize
        {
            get
            {
                return notepadSettings.FontSize;
            }
            set
            {
                notepadSettings.FontSize = value;
                OnPropertyChanged(nameof(FontSize));
            }
        }

        public FontFamily Font
        {
            get
            {
                return notepadSettings.Font;
            }
            set
            {
                notepadSettings.Font = value;
                OnPropertyChanged(nameof(Font));
            }
        }

        public string Text
        {
            get
            {
                return textFile.Text;
            }
            set
            {
                textFile.Text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        public ICommand newFileCommand { get; }
        public ICommand openFileCommand { get; }
        public ICommand saveFileCommand { get; }
    }
}
