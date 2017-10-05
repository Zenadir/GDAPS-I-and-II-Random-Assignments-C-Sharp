using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace PE13_GD
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D badTexture;
        Rectangle bRectangle;
        Vector2 changeRectangle;
        SpriteFont spritey;
        string ScreenText = null;

        Random r;
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
            // TODO: Add your initialization logic here

            bRectangle = new Rectangle(0, 0, GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);
            r = new Random();
            

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            badTexture = Content.Load<Texture2D>("why god");
            spritey = Content.Load<SpriteFont>("Spritey");
            
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

           ScreenText = DrawNeatRecursiveThing(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, Color.White).ToString();

            spriteBatch.DrawString(spritey, ScreenText, new Vector2(430, 200), Color.Teal);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public int DrawNeatRecursiveThing( int x, int y, int width, int height, Color color)
        {

            spriteBatch.Draw(badTexture, new Rectangle( x, y, width, height), color);

            if (width >= 1 || height > 1)
            {
                color.R += (byte)r.Next(-20,20);
                color.G = color.R;
                color.B = color.G;
                color.A -= 100;
                return 1 + DrawNeatRecursiveThing(x, y, width / 2, height / 2, color) +  DrawNeatRecursiveThing(x + (width / 2), y + height / 2, width / 2, height / 2, color);
            }

            else return 1;
        }
    }
}
