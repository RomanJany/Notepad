using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.Models
{
    public class TraversableStack<T>
    {
        private Stack<T> _mainStack;
        private Stack<T> _historyStack;

        public TraversableStack()
        {
            _mainStack = new Stack<T>();
            _historyStack = new Stack<T>();
        }
    }
}
