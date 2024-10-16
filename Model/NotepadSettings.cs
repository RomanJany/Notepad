using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Notepad.Model
{
    public class NotepadSettings
    {
        public enum NotepadTheme
        {
            Light,
            Dark
        }

        private NotepadTheme _theme;
        public NotepadTheme Theme
        {
            get
            {
                return _theme;
            }
            set
            {
                _theme = value;
            }
        }

        private double _fontSize;
        public double FontSize
        {
            get
            {
                return _fontSize;
            }
            set
            {
                _fontSize = value;
            }
        }

        private FontFamily _font;
        public FontFamily Font
        {
            get
            {
                return _font;
            }
            set
            {
                _font = value;
            }
        }

    }
}
