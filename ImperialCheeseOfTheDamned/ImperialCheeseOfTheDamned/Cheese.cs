using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImperialCheeseOfTheDamned
{
    class Cheese
    {

        public int Calories { get; set; }
        public string Name { get; set; }
        public float Age { get; set; }
        public bool Mold { get; set; }

        public override string ToString()
        {
            return Name + " " + Age + " " + Calories + " " + Mold;
                
        }

    }
}
