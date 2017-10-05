using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomStack
{
	class Program
	{
		static void Main(string[] args)
		{
            GameStack gS = new GameStack();
            for (int i = 0; i < 11; i++)
            {
     
                Console.WriteLine("Pushing " + i);
                gS.Push(i.ToString());
            }

            Console.WriteLine("\n Popping:");

            while (!gS.IsEmpty)
            {
                Console.WriteLine(gS.Pop());
            }

            Console.ReadLine();
		}
	}
}
