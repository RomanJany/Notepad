using Notepad.Commands;
using Notepad.Model;
using Notepad.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            TextHistory = new TraversableStack<string>();

            newFileCommand = new NewFileCommand(this);
            openFileCommand = new OpenFileCommand(this);
            saveFileCommand = new SaveFileCommand(this);
            saveAsFileCommand = new SaveAsFileCommand(this);
            printCommand = new PrintCommand(this);
            setFontSizeCommand = new SetFontSizeCommand(this);
            undoCommand = new UndoCommand(this);
        }

        private ObservableCollection<double> _fontSizeCollection = [8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72];
        public ObservableCollection<double> FontSizeCollection
        {
            get
            {
                return _fontSizeCollection;
            }
        }

        public TraversableStack<string> TextHistory;

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
                UpdateWindowTitle();
                OnPropertyChanged(nameof(textFile));
                OnPropertyChanged(nameof(Text));
                OnPropertyChanged(nameof(FilePath));
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
                UpdateWindowTitle();
                try
                {
                    TextHistory.Push(textFile.Text);
                    ((UndoCommand) undoCommand).OnCanExecuteChanged();
                }
                catch { }

                textFile.Text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        public string FilePath
        {
            get
            {
                return textFile.Path;
            }
            set
            {
                textFile.Path = value;
                OnPropertyChanged(nameof(FilePath));
            }
        }

        public bool FileSaved
        {
            get
            {
                return textFile.IsSaved;
            }
        }

        public ICommand newFileCommand { get; }
        public ICommand openFileCommand { get; }
        public ICommand saveFileCommand { get; }
        public ICommand saveAsFileCommand { get; }
        public ICommand printCommand { get; }
        public ICommand setFontSizeCommand { get; }
        public ICommand undoCommand {  get; }

        void UpdateWindowTitle()
        {
            string fileName;
            if (FilePath == "")
            {
                fileName = "Unitled";
            }
            else
            {
                string[] pathArray = FilePath.Split("\\");
                fileName = pathArray.Last();
            }

            if (textFile.IsSaved)
            {
                Application.Current.MainWindow.Title = fileName;
            }
            else
            {
                Application.Current.MainWindow.Title = fileName + "*";
            }
        }
    }
}
