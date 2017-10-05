using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomQueue
{
    class GameQueue : IQueue
    {
        private int count = 0;

        string[] players = new string[30];

        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
            }
        }

        public bool IsEmpty
        {
            get
            {
                if(count == 0)
                {
                    return true;
                }

                return false;
            }
        }

        public string Dequeue()
        {
            if(IsEmpty)
            {
                Console.WriteLine("The queue is empty");
                return null;
            }

            string tempstring = players[count-1];
            players[count-1] = null;
            --count;
            return tempstring;
        }

        public void Enqueue(string str)
        {
            if(count == 30)
            {
                Console.WriteLine("The queue is full.");
                return;
            }

            for (int i = (count-1); i > -1; --i)
            {
                players[i +1] = players[i];
            }

            players[0] = str;

            ++count;
        }

        public string Peek()
        {
            return players[count-1];
        }
        
        public void DisplayArray()
        {
            foreach (string item in players)
            {
                if(item!= null)
                Console.WriteLine(item);
            }
        }
    }
}
