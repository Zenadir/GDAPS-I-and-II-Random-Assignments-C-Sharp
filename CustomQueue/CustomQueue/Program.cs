using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomQueue
{
	class Program
	{
		static void Main(string[] args)
		{
            GameQueue gQ = new GameQueue();

            gQ.Enqueue("A");
            gQ.Enqueue("b");
            gQ.Enqueue("c");
            gQ.Enqueue("d");
            gQ.Enqueue("e");
            gQ.Enqueue("f");
            gQ.Enqueue("g");
            gQ.Enqueue("h");
            gQ.Enqueue("i");
            gQ.Enqueue("j");
            gQ.Enqueue("k");
            gQ.Enqueue("l");
            gQ.Enqueue("m");
            gQ.Enqueue("n");
            gQ.Enqueue("o");
            //gQ.Enqueue("k");
            //gQ.Enqueue("l");
            //gQ.Enqueue("m");
            //gQ.Enqueue("n");
            //gQ.Enqueue("o");
            //gQ.Enqueue("p");
            //gQ.Enqueue("q");
            //gQ.Enqueue("r");
            //gQ.Enqueue("s");
            //gQ.Enqueue("t");
            //gQ.Enqueue("u");
            //gQ.Enqueue("v");
            //gQ.Enqueue("w");
            //gQ.Enqueue("x");
            //gQ.Enqueue("y");
            //gQ.Enqueue("z");
            //gQ.Enqueue("1");
            //gQ.Enqueue("2");
            //gQ.Enqueue("3");
            //gQ.Enqueue("4");
            //gQ.Enqueue("5");
            //gQ.Enqueue("6");
            //gQ.Enqueue("7");

            gQ.DisplayArray();

            while (gQ.Count != 0)
            {
                Console.WriteLine(gQ.Dequeue() + " has joined the server");
            }

            //Console.WriteLine("Enqueue");
            //gQ.Enqueue("Test1");
            //gQ.Enqueue("Test1");
            //gQ.Enqueue("Test1");

            //Console.WriteLine("\n");
            //gQ.DisplayArray();



            Console.ReadLine();
        }
	}
}
