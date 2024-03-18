using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TopDownShooter;

namespace TopDownShooter
{
    public class Main : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private World world; // Instance of the World class
        private SpriteFont uiFont; // Font for UI elements
        private UI ui; // Instance of the UI class
        public int NumKilled { get; set; }

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Initialize your window size and other settings here
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            uiFont = Content.Load<SpriteFont>("font"); // Assuming you have a font file named "font.spritefont"

            // Create an instance of the World class
            world = new World(Content, this); // Pass reference to Main for potential drawing needs

            // Create an instance of the UI class and pass the graphics device manager
            ui = new UI(graphics);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            // Update the world based on the current GameState
            world.Update(gameTime);

            // Update the UI with the current world state and game time
            ui.Update(world, gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            // Draw the world based on the current GameState
            world.Draw(spriteBatch); // Pass the SpriteBatch instance

            // Draw UI elements using the UI class
            ui.Draw(world);

            spriteBatch.End();

            GraphicsDevice.Clear(Color.CornflowerBlue);
        }
    }
}

