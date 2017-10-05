using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurryMillitaryRunnerProj
{
    class Runner
    {
        public string Rank { get; set; }
        public string Costume{ get; set; }
        public string NickName { get; set; }
        public float Speed { get; set; }

        public override string ToString()
        {
            return NickName + " " + Costume;
        }
    }
}
