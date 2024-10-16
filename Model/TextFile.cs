using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.Model
{
    public class TextFile
    {
        TextFile()
        {
            _text = "";
            _fileName = "";
            IsSaved = false;
        }

        TextFile(string path) : this()
        {
            OpenFile();
        }

        public void OpenFile()
        {
            throw new NotImplementedException();
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
            }
        }

        private string _fileName;

        public string FileName
        { 
            get 
            { 
                return _fileName; 
            } 
            set
            {
                _fileName = value;
            }
        }

        public bool IsSaved { get; private set; }
    }
}
