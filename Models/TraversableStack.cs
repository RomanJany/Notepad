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

        public void Push(T item)
        {
            throw new NotImplementedException();
        }

        public T Pop()
        {
            throw new NotImplementedException();
        }

        public T Back()
        {
            throw new NotImplementedException();
        }

        public T Peek()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool CanPop()
        {
            throw new NotImplementedException();
        }

        public bool CanGoBack()
        { 
            throw new NotImplementedException(); 
        }
    }
}
