using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GD_Homework_5_Actual
{
    class Player
    {
        //A GameBoard object to be used when
        //checking if movement is valid.
        GameBoard board;


        //The position and size of the player.
        public Rectangle position = new Rectangle(10, 10, 25, 25);

        //The sprite of the target:
        //It is assigned in loadContent in Game1
        public Texture2D playerSprite = null;

        //Variables used to keep track of the position of the player
        //in regard to the array of data in board. 
        public int xPos = 0;
        public int yPos = 0;

       
        //A random object. It is inherited from the game board
        Random r;

        //Used to represent the direction that the player will try to move next.
        //A random number is generated to determine this direction.
        //Check below in the move method for more details.
        int moveNext = 0;

        //Used to keep track of whether or not the player has touched the target. 
        public bool Intersected { get; set; } = false;

        //A constructor that takes a random number generator and the GameBoard
        public Player( Random rng, GameBoard gB)
        {
            r = rng;
            board = gB;
        }

        //A method that causes the player to move around the board randomly.
        public void Move()
        {
            //While the target has not touched the player (changed through GameBoard's intersection method)
            while (Intersected == false)
            {
                //Every move the player will sleep for 250-350 msec before doing the next move.
                Thread.Sleep(r.Next(250, 351));

                //Output the new position to the console.
                Console.WriteLine("Player X-Position: " + position.X + " , Player Y-Position: " + position.Y);

                //Generate a random direction to move in next (up, left, down, or right)
                moveNext = r.Next(-1, 3);

                //Depending on the direction generated, check if it is a valid direction to move in. 
                switch (moveNext)
                {
                    //If the player is able to move in that direction, move the player in that direction.
                   
                    //Move left 
                    case -1:
                        if (board.validPosition(moveNext, xPos, yPos))
                        {
                            position.X -= 50;
                            --xPos;
                        }

                        break;

                    //Move right
                    case 0:
                        if (board.validPosition(moveNext, xPos, yPos))
                        {
                            position.X += 50;
                            ++xPos;
                        }

                        break;

                    //Move up
                    case 1:
                        if (board.validPosition(moveNext, xPos, yPos))
                        {
                            position.Y -= 50;
                            --yPos;
                        }

                        break;

                    //Move down
                    case 2:
                        if (board.validPosition(moveNext, xPos, yPos))
                        {
                            position.Y += 50;
                            ++yPos;
                        }


                        break;

                    default:
                        break;


                }
                

            }

            

        }


    }
}
