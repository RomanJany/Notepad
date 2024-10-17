using Notepad.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Notepad.Model
{
    public class NotepadSettings
    {
        public NotepadSettings(string path) 
        {
            Path = path;
            try 
            {
                Open();
            }
            catch
            {
                // Default values
                Theme = NotepadTheme.Light;
                FontSize = 12;
                Font = new FontFamily("Segoe UI");

                try
                {
                    Save();
                }
                catch { }
            }
        }

        private void Open()
        {
            JsonNode node = JsonNode.Parse(File.ReadAllText(Path));

            // Check if all the required properties are stored inside a settings file
            if ((node.AsObject().TryGetPropertyValue("Theme", out JsonNode themeNode)) &&
                (node.AsObject().TryGetPropertyValue("FontSize", out JsonNode fontSizeNode)) &&
                (node.AsObject().TryGetPropertyValue("Font", out JsonNode fontNode)))
            {
                double fontSize = (double) fontSizeNode;
                FontFamily fontFamily = new FontFamily((string) fontNode);
                NotepadTheme theme;
                switch ((string) themeNode)
                {
                    case "Light":
                        theme = NotepadTheme.Light;
                        break;
                    case "Dark":
                        theme = NotepadTheme.Dark;
                        break;
                    default:
                        throw new InvalidSettingsException();
                }

                // Once all properties are loaded successfully they are saved
                FontSize = fontSize;
                Font = fontFamily;
                Theme = theme;
            }
            else
            {
                throw new InvalidSettingsException();
            }
        }

        private void Save() 
        { 
            throw new NotImplementedException(); 
        }

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

        public string Path { get; private set; }

    }
}
