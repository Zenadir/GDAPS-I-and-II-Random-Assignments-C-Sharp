using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RobotYetiSquadron
{
    class Yeti
    {
        public string Species { get; set; }

        public int Health { get; set; }

        public override string ToString()
        {
            Thread.Sleep(Health * 1000);
            return Species + " woke up";
        }
    }
}
