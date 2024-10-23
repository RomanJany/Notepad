using Notepad.AttachedProperties;
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

            FindVisibility = Visibility.Collapsed;
            ReplaceVisibility = Visibility.Collapsed;

            newFileCommand = new NewFileCommand(this);
            openFileCommand = new OpenFileCommand(this);
            saveFileCommand = new SaveFileCommand(this);
            saveAsFileCommand = new SaveAsFileCommand(this);
            printCommand = new PrintCommand(this);
            setFontSizeCommand = new SetFontSizeCommand(this);
            undoCommand = new UndoCommand(this);
            redoCommand = new RedoCommand(this);
            showFindCommand = new ShowFindCommand(this);
            showReplaceCommand = new ShowReplaceCommand(this);
            hideFindAndReplaceCommand = new HideFindAndReplaceCommand(this);
            findNextCommand = new FindNextCommand(this);
            findPreviousCommand = new FindPreviousCommand(this);
        }

        public string FindText { get; set; }
        public string ReplaceText { get; set; }

        private Visibility _findVisibility;
        public Visibility FindVisibility
        {
            get
            {
                return _findVisibility;
            }
            set
            {
                _findVisibility = value;
                _replaceVisibility = Visibility.Collapsed;
                OnPropertyChanged(nameof(FindVisibility));
                OnPropertyChanged(nameof(ReplaceVisibility));
            }
        }

        private Visibility _replaceVisibility;
        public Visibility ReplaceVisibility
        {
            get
            {
                return _replaceVisibility;
            }
            set
            {
                _replaceVisibility = value;
                _findVisibility = value;
                OnPropertyChanged(nameof(ReplaceVisibility));
                OnPropertyChanged(nameof(FindVisibility));
            }
        }

        public TraversableStack<int> CaretIndexHistory
        {
            get
            {
                return textFile.CaretHistory;
            }
            set
            {
                textFile.CaretHistory = value;
            }
        }

        public string CaretPosition
        {
            get
            {
                return CaretIndex.ToString();
            }
        }

        public string TextLength
        {
            get
            {
                if (Text.Length == 1)
                {
                    return "1 character";
                }
                else
                {
                    return Text.Length.ToString() + " characters";
                }
            }
        }

        private int _caretIndex;
        public int CaretIndex
        {
            get
            {
                return _caretIndex;
            }
            set
            {
                _caretIndex = value;
                OnPropertyChanged(nameof(CaretIndex));
            }
        }

        private ObservableCollection<double> _fontSizeCollection = [8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72];
        public ObservableCollection<double> FontSizeCollection
        {
            get
            {
                return _fontSizeCollection;
            }
        }

        public TraversableStack<string> TextHistory
        {
            get
            {
                return textFile.TextHistory;
            }
            set
            {
                textFile.TextHistory = value;
            }
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
                textFile.Text = value;

                UpdateWindowTitle();

                try
                {
                    TextHistory.Push(textFile.Text);
                    CaretIndexHistory.Push(CaretIndex);
                    ((UndoCommand)undoCommand).OnCanExecuteChanged();
                    ((RedoCommand)redoCommand).OnCanExecuteChanged();
                }
                catch { }
            
                OnPropertyChanged(nameof(Text));
                OnPropertyChanged(nameof(TextLength));
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
        public ICommand redoCommand { get; }
        public ICommand showFindCommand {  get; }
        public ICommand showReplaceCommand {  get; }
        public ICommand hideFindAndReplaceCommand { get; }
        public ICommand findNextCommand { get; }
        public ICommand findPreviousCommand { get; }

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
