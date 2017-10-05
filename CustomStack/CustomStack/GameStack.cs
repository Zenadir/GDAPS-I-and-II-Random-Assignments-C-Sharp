using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomStack
{
    class GameStack : IStack
    {
        List<string> stackling = new List<string>();
        public int Count { get; set; } = 0;

        public bool IsEmpty
        {
            get
            {
                if(Count == 0)
                {
                    return true;
                }

                return false;
            }
        }

        public string Peek()
        {
            return stackling.Last();
        }

        public string Pop()
        {
            string tempstring = Peek();
            stackling.Remove(stackling.Last());
            --Count;
            return tempstring;
            
        }

        public void Push(string str)
        {
            stackling.Add(str);
            ++Count;
        }
    }
}
