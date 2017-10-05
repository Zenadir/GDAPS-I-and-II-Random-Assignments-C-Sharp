using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace GD_HW_3_Actual_Final
{

    //Author: Gabryel Dworman
    //GDAPS II: Steve Maier
    //HW II
    //Description: A somewhat tolerable game where you have to collect 
    //objects on screen.
    //3/3/17
    public enum GameState
    {
        Menu,
        Game,
        GameOver
    }
    //A list of all the possible states within the game.
  
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch sBatch;
        //Create a spritebatch object

        SpriteFont spriteFont;
        //A spritefont used to print text to the viewport.

        Player mainChar;
        //The player object attribute.

        List<Collectible> pickups;
        //A list of collectibles.

        public GameState CurrentState = GameState.Menu;
        //Contains the current state of the game.
        //Initialized with the menu gamestate.
        public double Timer { get; set; }
        //A timer that counts down as the player
        //plays.

        public int CurrentLevel { get; set; }
        //Contains an integer representing the current level.
        //of the game

        public int MaxPickups { get; set; } = 6;

       
        //Contains all possible gamestates.
       
       
       Random r = new Random();

        //"Depending on your current state, your Update() method should also check the current game 
        //state andd check for the transition conditions. Your Draw() method shoul also check the current
        //game state to determine what to draw. 

        //The player should press the enter key to transition from Menu to the Game state, or from
        //Game over to menu. The game should continue until the timer hits 0.

        Texture2D playerTexture;
        Texture2D collectibleTexture;

        KeyboardState kbState = new KeyboardState();
        KeyboardState kbPrevious = new KeyboardState();
        //Two keyboard states to be used to keep track of the current
        //and previous input. 

        public string TitleName { get; set; } = "Spoderman Strikes again!";
        //String text used to display the title of the game. 

        Vector2 TitlePosition = new Vector2();
        //A position on the screen for the title of the game.
        //Initialized in the initialize method. 
        public string Instructions { get; set; } = "Press enter...";
        //String text used to display the title screen instructions.

        Vector2 InstructionPosition = new Vector2();

        Vector2 ScorePosition = new Vector2(150,10);
        Vector2 LevelPosition = new Vector2(70,10);
        Vector2 TimerPosition = new Vector2(20,10);
        //Instantiate the positions for the locations of the text vectors.

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

           mainChar = new Player(40, 40, 80, 80);
            //Create a new player, set their position and size
            
            pickups = new List<Collectible>();
            //A list containing all of the collectibles within any given level. 
            CurrentState = GameState.Menu;

            TitlePosition.X = GraphicsDevice.Viewport.Width / 3;
            TitlePosition.Y = GraphicsDevice.Viewport.Height / 2;
            //Set the position of the game title to roughly the center of the screen.

            InstructionPosition.X = GraphicsDevice.Viewport.Width / 3;
            InstructionPosition.Y = GraphicsDevice.Viewport.Height / 2 +80;
            //Set the position of the instructions to under the title of the game. 

            base.Initialize();
        }
        


        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            sBatch = new SpriteBatch(GraphicsDevice);
            //Create a new spritebatch called sBatch to draw everything on screen. 

            playerTexture = Content.Load<Texture2D>("GreenGoblin");
            mainChar.Texture = playerTexture;
            //Load and set the player texture.
            //(In this case it should be an image of the green goblin from Spiderman)

            collectibleTexture = Content.Load<Texture2D>("Hobgoblin");
            //Load and set the texture of the collectible item 
            //(In this case it should be a picture of the hobgoblin from Spiderman.

            spriteFont = Content.Load<SpriteFont>("font");
            //Load a spritefont. Its pretty generic.
            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 



        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            #region Finite State Machine (Game Logic)

            if(CurrentState == GameState.Menu)
            {
                kbState = Keyboard.GetState();
                if(SingleKeyPress(Keys.Enter) == true)
                {
                    CurrentState = GameState.Game;
                    ResetGame(mainChar, pickups);
                }
            }
            //If the player is on the menu screen:
            //If they press enter, begin gameplay
            //by setting the current gamestate to Game.

            
            if(CurrentState == GameState.Game)
            {

                kbState = Keyboard.GetState();

                Timer -= gameTime.ElapsedGameTime.TotalSeconds;

                #region Movement Input

                if(kbState.IsKeyDown(Keys.A) == true)
                {
                    mainChar.Position.X -= 4;
                }

                if (kbState.IsKeyDown(Keys.D) == true)
                {
                    mainChar.Position.X += 4;
                }

                if (kbState.IsKeyDown(Keys.W) == true)
                {
                    mainChar.Position.Y -= 4;
                }

                if (kbState.IsKeyDown(Keys.S) == true)
                {
                    mainChar.Position.Y += 4;
                }

                #endregion Movement Input
                //If the player presses any of the WASD keys
                //during gameplay, move the character in the
                //apropriate direction depending on the key they pressed
                //(A = left, S = down, D = right, W = up)

                kbPrevious = kbState;

                ScreenWrap(mainChar);
                //If the player would move off screen, instead set their
                //position to the opposite side of the screen.

                foreach (Collectible item in pickups)
                {
                    if(item.Collision(mainChar) == true)
                    {
                        item.Active = false;
                        mainChar.LevelScore++;
                        mainChar.TotalScore++;
                    }
                }
                //Foreach collectible, check for collision.
                //Add 1 to the players total and current score. 
                //Set the collectible to false so that it isnt drawn. 

                if(mainChar.LevelScore == MaxPickups)
                {
                    NextLevel(mainChar, pickups);
                }
                //If the player has collected a number of 
                //pickups equal to the max number of pickups:
                //Start a new level.
                
                if(Timer <= 0)
                {
                    CurrentState = GameState.GameOver;
                }
                //If the timer runs out, set the game state to GameOver

            }

            if(CurrentState == GameState.GameOver)
            {
                kbState = Keyboard.GetState();
                if (SingleKeyPress(Keys.Enter) == true)
                {
                    CurrentState = GameState.Menu;
                }



            }
            //If the player lost the game:
            //Wait for the player to press enter.
            //This will return them to the menu screen.     

            #endregion Finite State Machine


            base.Update(gameTime);
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            sBatch.Begin();
            
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if(CurrentState == GameState.Menu)
            {
                sBatch.DrawString(spriteFont, TitleName, TitlePosition, Color.White);

                sBatch.DrawString(spriteFont, Instructions, InstructionPosition, Color.White);
            }
            //If the platyer is on the menu screen:
            //Draw the apropriate text in their respective positions (the title, the instructions)

            if(CurrentState == GameState.Game)
            {
                mainChar.Draw(sBatch);
                //Draw the player

                foreach (Collectible item in pickups)
                {
                    item.Draw(sBatch);
                }
                //Draw the player

                sBatch.DrawString(spriteFont, String.Format("{0:0.00}", Timer), TimerPosition, Color.White);
                //Draw the game timer on screen. 
                sBatch.DrawString(spriteFont, "Level: " + CurrentLevel.ToString(), LevelPosition, Color.White);
                //Draw the integer representing the current level on the screen. 
                sBatch.DrawString(spriteFont, mainChar.LevelScore.ToString(), ScorePosition, Color.White);
                //Draw the players current score on screen. 
            
            }

            if(CurrentState == GameState.GameOver)
            {
                sBatch.DrawString(spriteFont, "Game Over", TitlePosition, Color.White);
                sBatch.DrawString(spriteFont, "Total Score: " + mainChar.TotalScore.ToString(), InstructionPosition, Color.White);
            }
            //If the game is over, alert the player by displaying 'Game Over' on the screen.

            // TODO: Add your drawing code here

            base.Draw(gameTime);

            sBatch.End();
        }


        #region Methods



        public void NextLevel(Player pL , List<Collectible> pUps)
        {
            ++CurrentLevel;
            //Increment the number for the current level.

            Timer = 8;
            //Reset the timer

            pL.TotalScore += pL.LevelScore;
            // Add the player's current score to their total score.

            pL.LevelScore = 0;
            //Set the player's level score to 0

            pUps.Clear();
            //Clear the list of pickups.

            MaxPickups += r.Next(1, 4);
            //Increas ethe number of pickups spawned by a number from 1-3

            for (int i = 0; i < MaxPickups; i++)
            {
                Collectible cL = new Collectible(5 + r.Next(0, GraphicsDevice.Viewport.Width - 5), 5 + r.Next(0, GraphicsDevice.Viewport.Height - 5), 50, 50);
                cL.Texture = collectibleTexture;
                pickups.Add(cL);
            }
            //Spawn a number of pickups equal to Maxpickups, setting their position to a random set of coordinates within the viewport.
            //Set their size to 50;

        }

        public void ResetGame(Player pL, List<Collectible> pUps)
        {
            CurrentLevel = 0;
            pL.TotalScore = 0;
            NextLevel(pL, pUps);
        }
        //When the game is reset,
        //reset the current level,
        //reset the players score
        //Start a new level.

        public void ScreenWrap(GameObject gO)
        {
            if (gO.Position.X >= GraphicsDevice.Viewport.Width - 60)
            {
                gO.Position.X = 8;
            }

            if (gO.Position.X < 4)
            {
                gO.Position.X = GraphicsDevice.Viewport.Width - 70;
            }

            if (gO.Position.Y >= GraphicsDevice.Viewport.Height - 60)
            {
                gO.Position.Y = 8;
            }

            if (gO.Position.Y <= 4)
            {
                gO.Position.Y = GraphicsDevice.Viewport.Height - 70;
            }
        }
        //If a game object would move within 4 pixels of any border of the screen,
        //set the position of that object equal to 8 pixils away from the opposite border. 

        public bool SingleKeyPress(Keys key)
        {

            if (kbState.IsKeyDown(key) && kbPrevious.IsKeyDown(key))
            {
                return true;
            }
            kbPrevious = kbState;
            return false;
        }
        //Check to see if a key is being pressed and that it wasnt pressed in the previous frame.

        #endregion Methods
    }
}
