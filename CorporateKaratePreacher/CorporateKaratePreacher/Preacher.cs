using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateKaratePreacher
{
    class Preacher
    {
        public string Name { get; set; }
        public string Denomination { get; set; }
        public int Rank { get; set; }
        public int Ammo { get; set; }

        public override string ToString()
        {
            string buffer = Name + " " + Denomination + " " + Rank + " " + Ammo;
            //Stringbuilder!!!
            //buffer = string.Concat(Name, Denomination, Rank, Ammo); //For four strings or less, this is the fastest way to concatonate strings
            //buffer = string.Format("{0} {1} {2} {3}", Name, Denomination, Rank, Ammo);

            //stringBuilder sb = new StringBuilder();
            //sb.AppendFormat("{0} {1} {2} {3}");
        }

    }
}
