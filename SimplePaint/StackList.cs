using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePaint
{
    public class StackList<T> : List<T>
    {
        public void Push(T element)
        {
            Add(element);
        }

        public T Pop()
        {
            if (Count > 0)
            {
                int index = Count - 1;
                T element = this[index];
                RemoveAt(index);
                return element;
            }
            else
            {
                return default(T);
            }
        }
    }
}
