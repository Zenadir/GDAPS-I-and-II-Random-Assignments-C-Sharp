using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZombiePhonicsReal
{
    class Program
    {
        static void Main(string[] args)
        {
            Zombie z1 = new ZombiePhonicsReal.Zombie() { Word = "Quantum", Length = 5000, Color = ConsoleColor.Green };
            Zombie z2 = new ZombiePhonicsReal.Zombie() { Word = "cat", Length = 1000, Color = ConsoleColor.Yellow };
            Zombie z3 = new ZombiePhonicsReal.Zombie() { Word = "Failing the class", Length = 4000, Color = ConsoleColor.Cyan};

            z1.Speak();

            Thread t1 = new Thread(z1.Speak);
            t1.Name = "George";
            Thread t2 = new Thread(z2.Speak);
            t1.Name = "Ringo";
            Thread t3 = new Thread(z3.Speak);
            t1.Name = "John";
            t1.Start();
            t2.Start();
            t3.Start();
            //We have a memory variable that were trying to set and use on different threads. 
            //We have one color, but multiple threads are changing it. 
            //These threads are all running at the same time!!!!

            //If you pause a program, you can go to debug, windows, then threads. 
            //You cant go by the order of the threads in the threadlist. 

            Console.ReadLine();
        }
    }
}
