using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player = new Player();
        Player enemy = new Player();
        Color enemyColor = Color.Red;
        Random r = new Random();

        List<BadGuy> enemies = new List<BadGuy>(); 
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

            player.Texture = Content.Load<Texture2D>("sphere");
            player.Location = new Rectangle(100,100,100,100);

            enemy.Texture = Content.Load<Texture2D>("sphere");
            enemy.Location = new Rectangle(200, 200, 60, 60);

            for (int i = 0; i < 7; i++)
            {
                BadGuy bG = new BadGuy();
                bG.Location = new Rectangle(r.Next(5, GraphicsDevice.Viewport.Width - 5), r.Next(5, GraphicsDevice.Viewport.Height - 5), 50 + r.Next(1, 20), 70 + r.Next(1, 20));//GraphicsDevice.Viewport.Width - -5), r.Next(5, GraphicsDevice.Viewport.Height - -5), 50 + r.Next(1,20),  50 + r.Next(1, 20));
                bG.Texture = Content.Load<Texture2D>("doctor");
                enemies.Add(bG);
            }
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
            var ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.A))
            {
                player.Location.X -= 10;
            }
            if (ks.IsKeyDown(Keys.W))
            {
                player.Location.Y -= 10;
            }
            if (ks.IsKeyDown(Keys.D))
            {
                player.Location.X += 10;
            }
            if (ks.IsKeyDown(Keys.S))
            {
                player.Location.Y += 10;
            }

           
            // TODO: Add your update logic here
            //p.Location.X += 10;
            //p.MyProperty = new Rectangle(p.MyProperty.X+10, p.MyProperty.Y, p.MyProperty.Width, p.MyProperty.Height);

            if(player.Location.Y >= GraphicsDevice.Viewport.Height -3)
            {
                player.Location.Y = 9;
            }
            if (player.Location.Y <= 6)
            {
                player.Location.Y = GraphicsDevice.Viewport.Height - 9;
            }
            if (player.Location.X >= GraphicsDevice.Viewport.Width - 3)
            {
                player.Location.X = 9;
            }
            if (player.Location.X <= 3)
            {
                player.Location.X = GraphicsDevice.Viewport.Width - 9;
            }

            foreach (BadGuy eM in enemies)
            {
                eM.CheckCollision(player);
                eM.Location = new Rectangle(eM.Location.X + r.Next(1, 4) - r.Next(1, 4), eM.Location.Y + r.Next(1, 4) - r.Next(1, 4), eM.Location.Width + r.Next(1, 4) - r.Next(1, 4), eM.Location.Height+ r.Next(1, 4) - r.Next(1, 4));

            }
            //new Rectangle(eM.Location.X + r.Next(1, 4) - r.Next(1, 4), eM.Location.Y + r.Next(1, 4) - r.Next(1, 4), eM.Location.Height + r.Next(1, 4) - r.Next(1, 4), eM.Location.Width + r.Next(1, 4) - r.Next(1, 4));
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
            spriteBatch.Draw(player.Texture, player.Location, Color.White);

            foreach (BadGuy eM in enemies)
            {
                if (eM.Active == true)
                {
                    spriteBatch.Draw(eM.Texture, eM.Location, eM.badColor);
                }
                
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
