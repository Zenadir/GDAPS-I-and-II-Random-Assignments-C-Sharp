using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RobotYetiSquadron
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Yeti> squadron = new List<Yeti>();
            Yeti y1 = new Yeti { Health = 10, Species = "Bigfoot" };

            object locker = new object();

            Thread pThread = new Thread(() =>
            {
                while (true)
                {
                    lock (locker);
                    foreach (object item in squadron)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
            });
            pThread.Start();
           
            squadron.Add(y1);
            squadron.Add(new Yeti { Health = 20, Species = "Yeti" });

            lock (locker)
            {
                squadron.Add(new Yeti { Health = 12, Species = "Yeti" });
                squadron.Add(new Yeti { Health = 5, Species = "Leprchon" });
            }

            foreach (var item in squadron)
            {
                var t = new Thread(() => //Actually says: im defining this function by doing this next thing. This is called an anonymous functions
                {
                    item.ToString();
                    squadron.Remove(item);
                });
                t.Start();


            }
        }
    }
}
