using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GD_Homework_5_Actual
{
    class GameBoard
    {
        //The dimensions of the 2D array that will hold data for
        //the board.
        const int ARRAY_BOUND = 8;

        //The 2D array that holds data for the content of the board.
        //It is loaded in through the readBoard method. 
        public int[,] boardData = new int[ARRAY_BOUND, ARRAY_BOUND];

        //The position and dimensions of the board.
        public Rectangle boardSize = new Rectangle(0,0, 400,400);

        //The sprite of the board.
        //It is assigned in loadcontent.
        public Texture2D boardSprite = null;

        //A bool to be used if an exception is thrown during the loading method.
        //It prevents the threads from starting. 
        bool abortThreads = false;


        //A random number generator.
        Random r;

        //member variables for the player and the target.
        //They are initialized in the constructor.
        public Target targ;
        public Player play;

        //Threads for the player, the target, and for a method
        //that the board uses to check collision between them.
        Thread playerThread;
        Thread targetThread;
        Thread collisionThread;


        //The constructor for the board
        public GameBoard()
        {
            //Load in the data for the board's content.
            readBoard("board.csv");

            //Initialize the random number generator
            r = new Random();

            //Initialize the player and the target, passing
            //the random number generator and the board.
            targ = new Target(r, this);
            play = new Player(r, this);

            //Assign the player and target movement methods to threads
            //as well as the checkIntersection method. 
            playerThread = new Thread(play.Move);
            targetThread = new Thread(targ.Move);
            collisionThread = new Thread(checkIntersection);

            //If an exception wasn't thrown
            if(abortThreads == false)
            {
                //Start all of the threads.
                playerThread.Start();
                targetThread.Start();
                collisionThread.Start();
            }
          
            
        }


        //A method to load in the data for the board.
        public void readBoard(string textFile)
        {
            //Prepare to catch exceptions
            try
            {
                //Create a streamreader with the filename passed to the method.
                StreamReader reader = new StreamReader(textFile);

                //A variable to temporarily hold the data for each line read in through the streamreader.
                string tempstring = null;

                //An array to hold the split up data from tempstring. 
                string[] arrayHolder = new string[ARRAY_BOUND*ARRAY_BOUND];
            
                //For each row in the array
                for (int i = 0; i < ARRAY_BOUND; i++)
                {
                    //Read in a line of data into tempstring
                    tempstring = reader.ReadLine();

                    //Split up that data and store it into the array (as 1s and 0s)
                    arrayHolder = tempstring.Split(',');

                    //For each column of the array
                    for (int j = 0; j < ARRAY_BOUND; j++)
                    {
                        //store a piece of the data from arrayholder into boardData.
                        int.TryParse(arrayHolder[j], out boardData[i, j]);
                    }
                }

                //Close the file.
                reader.Close();
            }

            //If there's an error, write its message out on the console.
            catch (Exception msg)
            {
                Console.WriteLine(msg.Message);

                //Prevent the threads from starting.
                abortThreads = true;
               
            }
            
        }
    
        //A method called by the player and target to check if the position
        //that they are about to move into is valid. 
        public bool validPosition(int direction, int xPos, int yPos)
        {

            //Prepare to catch exceptions
            try
            {
                //Depending on the direction of the player or target's next movement:
                switch (direction)
                {
                        //Moving left 
                        case -1:
                        if (boardData[xPos - 1, yPos] == 0)
                            return true;

                        //If its not a valid movement
                        return false;

                        //Moving right
                        case 0:
                        if (boardData[xPos + 1, yPos] == 0)
                            return true;
                        return false;

                        //Moving up
                        case 1:
                        if (boardData[xPos, yPos - 1] == 0)
                            return true;
                        return false;

                        //Moving down
                        case 2:
                        if (boardData[xPos, yPos + 1] == 0)
                            return true;
                        return false;
   

                        default:

                        Console.WriteLine("This shouldn't ever happen.");
                        return false;
                }
            }

            //If the position is not valid, an exception will likely be thrown considering
            //that 
            catch (Exception)
            {
                return false;
            }
        }

        //A method used to check whether or not the board's player and
        //target are in the same spot
        public void checkIntersection()
        {
            //Always keep doing this (until the thread that's making it happen is aborted)
            while (true)
            {
                //If the target intersects with the player or vice versa (because sometime's it doesnt work with just one way)
                if (targ.position.Intersects(play.position) || play.position.Intersects(targ.position))
                {
                    //Set the player position to the target position.
                    play.position = targ.position;

                    //Mark intersected as true, preventing either of them from moving
                    play.Intersected = true;
                    targ.Intersected = true;

                    //Abort both the player's and the target's threads, again preventing them from moving.
                    playerThread.Abort();
                    targetThread.Abort();

                    //Abort the thread that is currently calling this method. 
                    collisionThread.Abort();


                }
            }
           
        }

        
    }
}
