using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GD_HW_1_GDAPS_2_REAL
{
    /// A class filled with methods that load 
    /// files necessary to play the game. 
   
    /// Also contains methods used to extract 
    /// random lines from 
    class ZombieData
    {
       
       private List<string> zombies = new List<string>();
        //A list of strings containing all zombie sprites.

       private List<string> phrases = new List<string>();
        //A list of strings containing all phrases

        public bool PFileFound { get; set; }
            //Keeps track of whether or not any phrase files were encountered.
            //If none were encountered, the gameplay loop ends. 

        public bool ZFileFound { get; set; }
        //Keeps track of whether or not any zombie files were encountered.
        //If none were encountered, the gameplay loop ends. 

        Random r = new Random();
        //A random object used to get a random phrase or zombie. 


        public ZombieData()
        {
            PFileFound = false;
            ZFileFound = false;
        }
        //The contstructor automatically sets p and z filesfound to false 
        //so that the player cannot progress if the program has not located
        //both sets of files.

        #region LoadPhrases
        public void LoadPhrases(string filename)
        {
            try
            {
                string tempString = "0";
                //Create a temporary string to hold the string data from the file.

                StreamReader phraseReader = new StreamReader(filename);
                //Create a streamreader to reade the apropriate file. 

                while (tempString != null)
                {
                    tempString = phraseReader.ReadLine();
                    if (tempString != null)
                    {
                        phrases.Add(tempString);
                    }
                }
                //While the temporary string has string data in it. 
                //Read the data from the filename. 
                //If the temporary string actually stored data:
                //add that data to the list of phrases.   

                PFileFound = true;                                    ///////////////VERY VERY VERY IMPORTANT///////////////;
                //If no exceptions occured, set pfiles found to true
                //so that the user can continue. 

                phraseReader.Close();
                //Cloes the file.
            }
            catch
            {
                Console.WriteLine("Error: No phrases file by the name of '" + filename + "' was encountered.");
                Console.ReadLine();
            }
        }
        #endregion LoadPhrases

        //Opens the file with the name entered within the parameter. 
        //Reads and stores the information of the file into the phrases attribute.

        //"Either check to see that the file exists first, or catch the file not found
        //exception. If the file isnt there, print an error to the console. 
        //If you opened it, close the file. 

        #region LoadZombies 
        public void LoadZombies()
        {

            #region Try
            try
            {
                string[] zombieDirectory = Directory.GetFiles(".", "Zombie*");
                 

                foreach (string item in zombieDirectory)
                {
                    string tempString = "0";
                    //A string used to store one line from the zombie text file before
                    //adding it to lineholder (see below).

                    string lineHolder = null;
                    //A string that holds all of the lines read from any one given zombie file.
                    int lineCount = 0;
                    //A variable holding the number of lines of the zombie file that have been stored thus far. 

                    StreamReader zombieReader = new StreamReader(item);
                    //Create a new streamreader for the zombie file.

                    while (tempString != null)
                    {
                        //While the temporary string doesnt contain any text:

                        tempString = zombieReader.ReadLine();
                        //Set tempstring equal to the first line of zombiereader. 

                        if (tempString != null)
                        {
                            //If the line of the zombie text file had something in it:

                            lineHolder += tempString + "\n";
                            //Add the value of that temporary string to lineholder
                            //So that all of the lines of the zombie file can be added up.

                            ++lineCount;
                            //Add one to "linecounter", counting the number of lines that have been added to the zombie thus far. 

                            if (lineCount >= 5)
                            {
                                //If five or more lines have been added to the zombie:

                                zombies.Add(lineHolder);
                                //Add all of the zombie lines to the zombie list.

                            } //End of lineCount if 

                        }//End of tempstring if 

                    }//End of tempstring while

                    zombieReader.Close();
                    //Cloes the file.
                }//End of Zombie directory foreach

               


                if (zombieDirectory[0] == null || zombies[0] == null)
                {
                    throw new FileNotFoundException();
                }                    

                ZFileFound = true;
                Console.WriteLine("Z Files Found");
                //if no errors occured, confirm that at least one zombie file has been found, allowing 
                //the game to continue.

            }//End of LoadZombie method
            #endregion Try

            catch
            {
                Console.WriteLine("Error: No zombie files were encountered.");
            }
                //If there is an error, alert the user that no zombie files were encountered.

        }
    #endregion LoadZombies 

        //Read x number of zombies from the appropriate zombie files. 
        //Get the files onto a directory and load them from that. 
        //"Catch exceptions silently", unless the number of files read was 0. 

        //Note: Zombie files are more than one line. Make sure they actually look
        //like the intentional zombies by the end. 

        public string RandomPhrases()
        {
           
            return phrases[r.Next(0, phrases.Count - 1)];
        }
        //Returns a random phrase from the phrases list.

        public string RandomZombie()
        {
            return zombies[r.Next(0, zombies.Count - 1)];
        }
        //Returns a random zombie. 


        

    }
}
