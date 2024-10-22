using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Notepad.AttachedProperties
{
    public static class TextBoxProperties
    {
        public static readonly DependencyProperty CaretIndexProperty =
        DependencyProperty.RegisterAttached(
            "CaretIndex",
            typeof(int),
            typeof(TextBoxProperties),
            new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, CaretIndexChanged));

        public static int GetCaretIndex(DependencyObject obj)
        {
            return (int)obj.GetValue(CaretIndexProperty);
        }

        public static void SetCaretIndex(DependencyObject obj, int value)
        {
            obj.SetValue(CaretIndexProperty, value);
        }

        private static void CaretIndexChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            TextBox textBox = (TextBox) obj;
            if (textBox != null)
            {
                textBox.CaretIndex = (int)e.NewValue;
            }
        }
    }
}
