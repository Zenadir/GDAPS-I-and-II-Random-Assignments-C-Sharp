using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace FullMetalSurgeryIncident
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D doctor;
        SpriteFont font;
        Song music;
        SoundEffect effect;


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

            doctor = Content.Load<Texture2D>("doctor");

            font = Content.Load<SpriteFont>("SPF");
            //font = Content.Load<SpriteFont>("myfont");

            //music = Content.Load<Song>("explosion3");
            //MediaPlayer.Play(music);

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
            //spriteBatch.Draw(doctor, new Vector2(100, 100), Color.ForestGreen);
            //spriteBatch.Draw(doctor, new Rectangle(200, 200, 200, 50), Color.PapayaWhip);
            //Stretched
            spriteBatch.Draw(doctor, position: new Vector2(100, 100), rotation:MathHelper.Pi,origin: new Vector2(50,50), scale: new Vector2(0.5f));
            //spriteBatch.Draw(doctor, new Vector2(100, 100), new Rectangle(0,0,100,100),  null, Color.BlanchedAlmond, 0, null, null, SpriteEffects.FlipHorizontally);

            spriteBatch.DrawString(font, "Killer Doctor", new Vector2(200, 200), Color.Black);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
