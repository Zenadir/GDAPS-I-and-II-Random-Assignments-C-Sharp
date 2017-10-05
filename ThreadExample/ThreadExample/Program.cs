using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadExample
{
    class Program
    {
        static void Main(string[] args)
        {

            //create a jack object
            SamuraiJack grant = new SamuraiJack(100);

            //create a new thread
            Thread alice = new Thread(grant.Move);
            //start the thread

            alice.Start(1);
            alice.Join();

            SamuraiJack james = new SamuraiJack(100);
            Thread jordan = new Thread(james.Move);
            jordan.Start(9);
            jordan.Join();


            //output at the end of the project 
            Console.WriteLine("Its the end dingus!");
            Console.ReadLine();
        }
    }
}
