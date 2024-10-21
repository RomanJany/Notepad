using Microsoft.Win32;
using Notepad.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.Model
{
    public class TextFile
    {
        public TextFile()
        {
            Text = "";
            Path = "";
            TextHistory = new TraversableStack<string>();
        }

        public TextFile(string path) : this()
        {
            // Tries to open a file, if it fails, sets path for new file
            try
            {
                OpenFile(path);
            }
            catch
            {
                Path = path;
                IsSaved = false;
            }
            
            TextHistory.Clear(Text);
        }

        public void OpenFile()
        {
            Text = File.ReadAllText(Path);
            IsSaved = true;
            TextHistory.Clear(Text);
        }

        public void OpenFile(string path)
        {
            Path = path;
            OpenFile();
        }

        public void SaveFile()
        {  
            File.WriteAllText(Path, Text);
            IsSaved = true;
        }

        public void SaveFile(string path)
        {
            Path = path;
            SaveFile();
        }

        public TraversableStack<String> TextHistory { get; set; }

        private string _text;

        public string Text 
        { 
            get 
            { 
                return _text; 
            } 
            set
            {
                _text = value;
                IsSaved = false;
            }
        }

        public string Path { get; set; }

        public bool IsSaved { get; private set; }
    }
}
