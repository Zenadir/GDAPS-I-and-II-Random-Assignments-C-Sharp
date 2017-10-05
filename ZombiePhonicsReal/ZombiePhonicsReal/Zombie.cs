using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ZombiePhonicsReal
{
    class Zombie
    {

        public int Length { get; set; }
        public string Word { get; set; }
        public ConsoleColor Color { get; set; }

        public void Speak()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(Word + "begin");
            Thread.Sleep(Length);
            Console.WriteLine(Word + "end");
        }

    }
}
