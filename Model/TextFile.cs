using Microsoft.Win32;
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
        }

        public TextFile(string path) : this()
        {
            OpenFile(path);
        }

        public void OpenFile()
        {
            Text = File.ReadAllText(Path);
            IsSaved = true;
        }

        public void OpenFile(string path)
        {
            Path = path;
            OpenFile();
        }

        public void SaveFile()
        {  
            throw new NotImplementedException(); 
        }

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
