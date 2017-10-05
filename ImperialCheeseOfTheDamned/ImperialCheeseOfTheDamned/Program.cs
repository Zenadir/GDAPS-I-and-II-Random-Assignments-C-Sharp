using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

namespace ImperialCheeseOfTheDamned
{
    class Program
    {
        static void Main(string[] args)
        {
            Cheese playerOne = new Cheese { Name = "Gouda", Age = 4.09f, Calories = 100, Mold = false };
            Cheese playerTwo = new Cheese { Name = "American Spray", Age = 0.01f, Calories = 1000, Mold = false };

            using (var output = File.OpenWrite("cheese.dat"))
            {
                var writer = new BinaryWriter(output);
                writer.Write(playerOne.Name);
                writer.Write(playerOne.Age);
                writer.Write(playerOne.Calories);
                writer.Write(playerOne.Mold);

                writer.Write(playerTwo.Name);
                writer.Write(playerTwo.Age);
                writer.Write(playerTwo.Calories);
                writer.Write(playerTwo.Mold);

            }
            //If you use using, you dont need to close the file and var output dissapears afterwords.
            // output.Close();

            Cheese readOne = new Cheese();
            using (var input = File.OpenRead("cheese.dat"))
            {
                using (var reader = new BinaryReader(input))
                {
                    readOne.Name = reader.ReadString();
                    readOne.Age = reader.ReadSingle();
                    readOne.Calories = reader.ReadInt32();
                    readOne.Mold = reader.ReadBoolean();

                }
                Console.WriteLine(readOne);
                //You can nes tyour usings together here like this. 
            }



            using (var output = File.OpenWrite("cheese.bson"))
            {
                var writer = new BsonWriter(output);
                JsonSerializer serial = new JsonSerializer();
                serial.Serialize(writer, playerOne);
            }

            string[] debug = Directory.GetFiles(".", "*.exe");
            //Looks for files in the current folder ( thats what the . is for) and looks for exe files. 
            foreach (var item in debug)
            {

            }

            //In the game, youre going to hav ea loop (that you can copy into your code:
            //Its not inside of the keyavaliable loop its outside. 
            //While console.key avaliable is going to happen alot!
        }
    }
}
