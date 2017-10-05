using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gd_LinkyLinkylist_ICE
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

            //list.Add("a");
            ////list.Clear();
            //list.Add("A");
            //list.Insert(0, "b");
            //list.Traverse();

            list.InsertSorted("momba");
            list.InsertSorted("Zulu");
            list.InsertSorted("jello");
            list.InsertSorted("ealpha");
            list.InsertSorted("Alpha2");
            list.InsertSorted("alpha2");
            list.Traverse();

            //list.Add("Space Invaders");
            //list.Add("Qbert");
            //list.Add("Dragons Lair");
            //list.Add("Defender");
            //list.Add("Pacman");
            //list.Add("gaunlet");

            //list.Traverse();

            //Console.WriteLine("\n\n");

            //list.Insert(4, "pong");

            //list.Traverse();
            //Console.WriteLine(list.GetData(4));

            Console.ReadLine();
        }
    }
}
