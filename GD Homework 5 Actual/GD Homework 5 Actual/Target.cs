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
    class Target
    {
        //A GameBoard object to be used when
        //checking if movement is valid.
        GameBoard board;

        //The position and size of the target.
        public Rectangle position = new Rectangle(360, 360, 25, 25);

        //The sprite of the target:
        //It is assigned in loadContent in Game1
        public Texture2D targetSprite = null;

        //Used to determine whether or not the target should
        //be able to move immediately again after touching a wall.
        bool justCollided;

        //Variables used to keep track of the position of the target
        //in regard to the array of data in board. 
        public int xPos = 7;
        public int yPos = 7;

        //A random object. It is inherited from the game board.
        Random r;

        //Used to represent the direction that the target will try to move next.
        //A random number is generated to determine this direction.
        //Check below in the move method for more details.
        int moveNext = 0;

        //Used to keep track of whether or not the player has touched the target. 
        public bool Intersected { get; set; } = false;

        //A constructor that takes a random number generator and the GameBoard
        public Target(Random rng, GameBoard gB)
        {
            r = rng;
            board = gB;
        }

        //A method that causes the target to move around the board randomly.
        public void Move()
        {
            //While the target has not touched the player (changed through GameBoard's intersection method)
            while (Intersected == false)
            {
                //As long as the target didn't just try to move into a wall
                if (!justCollided)
                {
                    //Make the target wait for 300-500 milliseconds.
                    Thread.Sleep(r.Next(300, 501));
                    //Output the new position to the console.
                    Console.WriteLine("Target X-Position: " + position.X + " , Target Y-Position: " + position.Y);
                   
                }

                //Set justCollided to false, marking that the target did not just try bumping into a wall
                justCollided = false;

                //Generate a random direction to move in next (up, left, down, or right)
                moveNext = r.Next(-1, 3);

                //Depending on the direction generated, check if it is a valid direction to move in. 
                switch (moveNext)
                {

                    //If the target is able to move in that direction, move the target in that direction.
                    //Otherwise, mark justCollided as true, as the target just tried bumping into a wall.
                    
                    //Move left 
                    case -1:
                        if (board.validPosition(moveNext, xPos, yPos))
                        {
                            position.X -= 50;
                            --xPos;
                        }
                        else
                        {
                            justCollided = true;
                        }

                        break;

                    //Move right
                    case 0:
                        if (board.validPosition(moveNext, xPos, yPos))
                        {
                            position.X += 50;
                            ++xPos;
                        }
                        else
                        {
                            justCollided = true;
                        }

                        break;

                    //Move up
                    case 1:
                        if (board.validPosition(moveNext, xPos, yPos))
                        {
                            position.Y -= 50;
                            --yPos;
                        }
                        else
                        {
                            justCollided = true;
                        }

                        break;

                    //Move down
                    case 2:
                        if (board.validPosition(moveNext, xPos, yPos))
                        {
                            position.Y += 50;
                            ++yPos;
                        }
                        else
                        {
                            justCollided = true;
                        }

                        break;

                    default:
                        Console.WriteLine("This should never happen");
                        break;

                }

               
            }                       

        }
     
    }
}
