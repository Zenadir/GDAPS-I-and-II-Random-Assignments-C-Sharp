using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurryMillitaryRunnerProj
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Runner> squad = new Dictionary<string, Runner>();
            squad.Add("Anna", new Runner()
            {
                NickName = "Anna",
            Costume = "Smurf",
            Rank = "Labbie",
            Speed = 2.4f

            });

            Runner r2 = new FurryMillitaryRunnerProj.Runner();
            r2.NickName = "Freddie";
            r2.Costume = "Cartoon Network";
            r2.Rank = "Producer";
            r2.Speed = 1.0f;
            squad.Add("Freddie", r2);

            var temp = squad["Anna"];
            Console.WriteLine(temp);
        }

    }
}
