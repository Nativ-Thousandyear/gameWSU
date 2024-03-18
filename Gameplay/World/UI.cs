#region Includes
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
// Remove unnecessary using statements
using TopDownShooter;

#endregion

namespace TopDownShooter
{
    public class UI
    {
        public QuantityDisplayBar healthBar;
        public SpriteFont scoreFont;
        private McTimer timer; // Use the existing McTimer class
        public World WorldInstance { get; set; } // Reference to the World instance

        public UI(GraphicsDeviceManager graphics)
        {
            scoreFont = Globals.content.Load<SpriteFont>("2d\\Misc\\Arial16");
            healthBar = new QuantityDisplayBar(new Vector2(104, 16), 1, Color.Red);

            // Initialize the countdown timer (assuming McTimer can be used as a countdown timer)
            

            TimeSpan initialTime = TimeSpan.FromMinutes(2);
            timer = new McTimer((int)initialTime.TotalMilliseconds, true);  // Start the timer immediately

        }

        public void Update(World world, GameTime gameTime)
        {
            healthBar.Update(world.Player.Health, world.Player.MaxHealth);
            timer.UpdateTimer(gameTime.ElapsedGameTime.Milliseconds);

            switch (world.worldGameState) // Access the value of the GameState property within the world object
            {
                case World.GameState.Playing:
                    // Code for Playing state
                    break;
                case World.GameState.Paused:
                    // Code for Paused state
                    break;
                case World.GameState.MainMenu:
                    // Code for MainMenu state (optional)
                    break;
                case World.GameState.GameOver:
                    // Code for GameOver state
                    break;
                case World.GameState.Win:
                    // Code for Win state (optional)
                    break;
                default:
                    // Code for unmatched states
                    break;
            }
        }



        private void UpdateUIWithTimer(World World)
        {
            // Access timer information (assuming McTimer provides relevant methods)
            double timeLeftInSeconds = timer.Timer / 1000.0; // Convert milliseconds to seconds

            if (timeLeftInSeconds <= 0)
            {
                // Handle timer expiration (e.g., set game state to GameOver)
                World.worldGameState = World.GameState.GameOver;

            }
            else
            {
                // Update UI elements based on remaining time (optional)
                string timerText = $"Time Left: {timeLeftInSeconds:00.0}";
                Vector2 timerPosition = new Vector2(300, 10); // Adjust position as needed
                Globals.spriteBatch.DrawString(scoreFont, timerText, timerPosition, Color.White); // Use scoreFont member variable
            }
        }

        public McTimer GetTimer()
        {
            return timer;
        }

        public virtual void Draw(World world) // Update based on world instance
        {
            // Draw the score
            string scoreText = "Score: " + world.Score;
            Vector2 scorePosition = new Vector2(10, 10); // position adjustable
            Globals.spriteBatch.DrawString(scoreFont, scoreText, scorePosition, Color.White);

            // Draw the health bar
            healthBar.Draw(new Vector2(20, Globals.screenHeight - 40));

            // Draw the timer
            // No need to call timer.Draw() as UI updates are handled in UpdateUIWithTimer
        }
    }
}
