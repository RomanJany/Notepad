using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.Models
{
    // Works like regular stack, but remembers history when using Pop() allowing return with Back()
    public class TraversableStack<T>
    {
        private Stack<T> _mainStack;
        private Stack<T> _historyStack;

        public TraversableStack()
        {
            _mainStack = new Stack<T>();
            _historyStack = new Stack<T>();
        }

        public void Push(T item)
        {
            _mainStack.Push(item);
            _historyStack.Clear();
        }

        public T Pop()
        {
            T item = _mainStack.Pop();
            _historyStack.Push(item);

            return item;
        }

        public T Back()
        {
            T item = _historyStack.Pop();
            _mainStack.Push(item);

            return item;
        }

        public T Peek()
        {
            return _mainStack.Peek();
        }

        public void Clear()
        {
            _mainStack.Clear();
            _historyStack.Clear();
        }

        public bool CanPop
        {
            get
            {
                return (_mainStack.Count != 0);
            }
        }

        public bool CanGoBack
        { 
            get
            {
                return (_historyStack.Count != 0);
            }
        }
    }
}
