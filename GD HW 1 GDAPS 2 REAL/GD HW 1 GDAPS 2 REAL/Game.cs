using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD_HW_1_GDAPS_2_REAL
{
    class Game
    {
        public int PlayerLife { get; set; }
        //Stores the player's HP

        public int Score { get; set; }

        public bool ZombieAlive { get; set; }
        //Checks whether or not a zombie has been spawned or is currently alive. 

        public int LetterIndex { get; set; }
        //Used to keep track of the current letter of the 
        //phrase that the player is trying to type. 

        public string CurrentWord { get; set; }
        //Used to store the current phrase that 
        //the player is trying to type. 

        public string CompareWord { get; set; }
        //When the player types letters, they are
        //added to this string. When this string
        //has all of the same content as the current word,
        //the player kills the zombie.

        public bool Bloodlust { get; set; }
        //A bool that, once zombietimer reaches the three second minimum (at 5500 points),
        //boosts hte amoutn of points that the player gets from killing a zombie and
        //prevents the timer from falling below 3 seconds. 

        public string CurrentZombie { get; set; }
        //A string that holds the text of the current zombie sprite.

        public double ZombieTimer { get; set; }
        //Counts down the amount of time that a player has before
        //they are hit by a zombie.

        ZombieData zData = new ZombieData();
        //An object used to load zombie and phrase .txt files 
        //and get random phrases / zombies. 

        public Game()
        {
            PlayerLife = 7;

            Score = 0;

            ZombieAlive = false;
            //The zombie starts out as dead.

            Bloodlust = false;
            //The player doesnt have bloodlust yet,
            //because their score hasnt reached

            ZombieTimer = 15;

            zData.LoadPhrases("phrases.txt");

            zData.LoadZombies();
            //Load the phrases and zombie files. 

            PlayGame();
        }

        public void PlayGame()
        {

            if (zData.PFileFound == true && zData.ZFileFound == true)
            {
                Console.WriteLine("Playing Game");
                //If all of the necessary file prerequisites were found (the phrases and the zombie art)


                while (PlayerLife > 0)
                {

                    //A string containing the word that the player is currently trying to spell. 

                    if (ZombieAlive == false)
                    {
                        ZombieAlive = true;
                        //Load the player's high score. 

                        if (Score < 5500)
                        {
                            ZombieTimer = 15 - Score * .0022;
                        }
                        //If the players score is less than 5500:
                        //Set the zombie timer to the equation above. 

                        else
                        {
                            if (Bloodlust == false)
                            {
                                Console.WriteLine("BLOODLUST MODE ENTERED!!!");
                                Bloodlust = true;
                            }

                            ZombieTimer = 3;
                        }
                        //If the player has a greater score than 5500, 
                        //set the zombietimer to 3, turn on bloodlust mode
                        //(allowing the player to get more points), and 
                        //tell the player that bloodlust mode is on. 

                        LetterIndex = 0;
                        Console.WriteLine("Score: " + Score);
                        //Print the player's score. 

                        Console.WriteLine("\nHealth: " + PlayerLife);

                        CurrentZombie = zData.RandomZombie();
                        //Store the current zombie sprite.

                        Console.WriteLine(CurrentZombie);
                        //Print that zombie sprite.
                        
                        Console.WriteLine("Time: ");
                        Console.WriteLine(Math.Round(ZombieTimer, 2));

                        CurrentWord = zData.RandomPhrases().ToUpper();
                        //Generate and store a random phrase from the list of phrases.
                        Console.WriteLine("Phrase: ");
                        Console.WriteLine(CurrentWord);
                        //Print a random phrase
                    }

                    while (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey();
                        string letter = key.KeyChar.ToString().ToUpper();
                        
                        if(LetterIndex > CurrentWord.Length-1)
                        {
                            LetterIndex = CurrentWord.Length - 1;
                        }
                        //If for some reason the letter index would ever be greater
                        //than the number of letters in the word, set that to be
                        //the number of letters in the word instead. 

                        if (letter != CurrentWord[LetterIndex].ToString())
                        {
                            //If the player types in a letter that is NOT the same
                            //as the letter of the index number ("letter x"):

                            LetterIndex = 0;
                            //Set the letter that the player is to type to 0.

                            Console.Write(":(");
                            //Write out a sad face to let the player know that 
                            //they messed up.

                            CompareWord = null;
                            //Empty compareword (so that the player has to start over).

                            System.Threading.Thread.Sleep(300);
                            Console.Clear();
                            //Wait a short amount of time before clearing the screen
                            //to punish the player before messing up. 

                            Console.WriteLine("Score: " + Score);
                            Console.WriteLine("\nHealth: " + PlayerLife);
                            Console.WriteLine(CurrentZombie);

                            if(Bloodlust == true)
                            {
                                Console.WriteLine(CurrentZombie);
                                Console.WriteLine(CurrentZombie);
                            }

                            Console.WriteLine("Phrase: ");
                            Console.WriteLine(CurrentWord);
                            //Reprint the image, score and health of the player
                            //on the console.

                            Console.WriteLine("Time: ");
                            Console.WriteLine(Math.Round(ZombieTimer, 2));
                            //Print the timers current time on the screen. 
                        }

                        if (letter == CurrentWord[LetterIndex].ToString())
                        {
                            //If the player types in a letter that IS the same
                            //as the letter of the index number ("letter x"):

                            Console.Write("!");
                            //write out an exclamaion point to alert the player
                            //that they typed the correct letter.

                            CompareWord += CurrentWord[LetterIndex].ToString();
                            //Add the letter to compareword.
                            ++LetterIndex;
                            //Increment the number keeping track of the current
                            //letter of the phrase being typed. 
                        }


                    }

                    if (CompareWord == CurrentWord)
                    {
                        //If the player has typed out the entire phrase:

                        Console.Clear();
                        //Clear the screen

                        CompareWord = null;
                        //Empty compareword

                        LetterIndex = 0;
                        //Set the current letter to compare to 
                        //the first letter.

                        ZombieAlive = false;
                        //Set the zombie to dead.

                        if (Bloodlust == false)
                        {
                            Score += 200;
                            //If bloodlust is off, add 200 points to the players score. 
                        }

                        else
                        {
                            Score += (int)Math.Ceiling(200 * (1 + ZombieTimer));
                            //If bloodlust is on, add to the players score equal to
                            //the equation above (greater than 200 points). 
                        }

                    }//End of compare = currentword if 

                    System.Threading.Thread.Sleep(50);
                    //wait 50 milliseconds

                    ZombieTimer -= .05;
                    //Subtract 50 milliseconds from the timer. 

                    if (ZombieTimer <= 0)
                    {
                        //If the player has ran out of time:

                        PlayerLife -= 1;
                        //Subtract 1 life from their HP

                        Console.WriteLine("\nYou were hit by the zombie!");
                        Console.WriteLine("Health: " + PlayerLife);
                        //Alert the player that they were hit and write their
                        //current health.

                        if (Score < 5500)
                        {
                            ZombieTimer = 15 - Score * .0022;
                            //reset the players timer normally if their score is below 5500
                        }

                        else
                        {
                            if (Bloodlust == false)
                            {
                                Console.WriteLine("BLOODLUST MODE ENTERED!!!");
                                Bloodlust = true;
                            }
                            ZombieTimer = 3;
                            //If the players score is above 5500,
                            //alert the player that they have entered bloodlust mode
                            //set bloodlst to true and set the player's timer to 3 seconds. 
                        }
                    }                          

                }

                Console.WriteLine("Final Score: " + Score);
                Console.WriteLine("Game Over");
                Console.ReadLine();
                if (PlayerLife <= 0)
                {
                    return;
                }
                
                //One the game has ended, write out the players score and tell them
                //the game has ended.
            }

        }
    }
}
