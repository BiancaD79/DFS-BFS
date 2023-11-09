using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackQueue
{
    public class MyStack<T> : GenericList<T>
    {
        public MyStack() : base()
        { }

        public override T Pop()
        {
            T toR = values[0];
            T[] temp = new T[values.Length - 1];
            for (int i = 0; i < values.Length - 1; i++)
            {
                temp[i] = values[i + 1];
            }
            values = temp;
            return toR;
        }
        public override string View()
        {
            return "Stack: " + base.View();
        }
    }
}
