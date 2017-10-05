using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadExample
{
    class SamuraiJack
    {
        //Property for heatlh 
        public int Health { get; set; } = 0;

        //Constructor taking the initial health

        Random r = new Random();
        public SamuraiJack(int hp)
        {
            Health = hp;
           
        }

        //move function

        public void Move(object min)
        {
            r = new Random();

            while ( Health>0)
            {
                TakeDamage(r.Next((int)min,10));
                Thread.Sleep(100);
            }
        }

        //take damage function that takes the amount to subtract from health

        public void TakeDamage(int dmg)
        {
            Health -= dmg;
            Console.WriteLine("Jack took " + dmg + " Damage.");
            if (Health <= 0)
            {
                    Console.WriteLine("Youdeadson");
            }
        }
    }
}
