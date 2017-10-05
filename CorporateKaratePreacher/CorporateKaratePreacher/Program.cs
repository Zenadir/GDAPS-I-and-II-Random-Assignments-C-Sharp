using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateKaratePreacher
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Preacher> employees = new List<Preacher>();
            employees.Add(new Preacher { Name = "George", Denomination = "God Himself", Rank = 1,  Ammo = 10 });
            employees.Add(new Preacher { Name = "Storm", Denomination = "Burrito", Rank = 5,  Ammo = 100 });



            try
            {
                int ammoSum = 0;
                int ammoCount = 0;
                foreach (var item in employees)
                {
                    ammoSum += item.Ammo;
                }
                float averageAmmo = ammoSum / ammoCount;
                Console.WriteLine("Average ");
            }
            catch (DivideByZeroException ex)
            catch (Exception ex)
            {
                Console.Write("There was an error " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }



            
        }
    }
}
