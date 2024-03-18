using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TopDownShooter.Source.Gameplay.World.Interfaces;
using TopDownShooter.Source.Gameplay.World.Units;

namespace TopDownShooter
{
    public class World
    {
        public enum GameState { Playing, Paused, MainMenu, GameOver, Win }
        public GameState worldGameState = GameState.Playing;

        private ContentManager content;
        private Main mainInstance; // Reference to Main instance for potential drawing needs

        private Player player;
        private int initialPlayerHealth = 100;
        private List<Enemy> enemies;

        private MenuManager menuManager;
        private GameTime gameTime;
        public IEnemyRouteFactory ZigZagRouteFactory { get; private set; } // Property for ZigZagRouteFactory
        public int Score { get; set; } // Property for game score
        public int NumKilled { get; set; }

        public World(ContentManager content, Main mainInstance)
        {

            this.content = content;
            this.mainInstance = mainInstance;

            // Initialize game world objects
            player = new Player(content.Load<Texture2D>("Player"), new Vector2(100, 100), initialPlayerHealth); // Pass initial health
            enemies = new List<Enemy>();

            // Define a specific starting velocity for the enemy (adjust as needed)
            Vector2 enemyVelocity = new Vector2(1.0f, 0.0f); // Move right at 1 unit per second
            enemies.Add(new Enemy(content.Load<Texture2D>("Enemy"), new Vector2(300, 200), enemyVelocity, null, gameTime, false));

            worldGameState = GameState.Playing;

            // Create MenuManager with appropriate initial state
            menuManager = new MenuManager(
                CreateGameMenuItems(),
                content,
                worldGameState
            );
        }

        public void Update(GameTime gameTime)
        {
            if (worldGameState == GameState.Playing)
            {
                // Update game logic
                player.Update(gameTime, GetPlayerInput());

                foreach (Enemy enemy in enemies)
                {
                    enemy.Update(gameTime, player); // Pass the player object
                }

                // TODO: Handle collisions, scorekeeping, etc. (add your logic)

                // Check for game over condition (example: player health <= 0)
                if (player.Health <= 0)
                {
                    worldGameState = GameState.GameOver;
                }
            }
            else if (worldGameState == GameState.Paused || worldGameState == GameState.MainMenu)
            {
                menuManager.Update(gameTime);
            }

            // Handle input for pausing/unpausing the game (example)
            if (Keyboard.GetState().IsKeyDown(Keys.Escape) && worldGameState == GameState.Playing)
            {
                worldGameState = GameState.Paused;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Escape) && (worldGameState == GameState.Paused || menuManager.IsSelected("Exit")))
            {
                // Additional logic for handling exit selection from menu (optional)
                worldGameState = GameState.Playing; // Or exit the game based on your design
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (worldGameState == GameState.Playing)
            {
                // Draw game world elements
                spriteBatch.Draw(player.Texture, player.Position, Color.White);

                foreach (Enemy enemy in enemies)
                {
                    spriteBatch.Draw(enemy.Texture, enemy.Position, Color.White);
                }


            }
            else if (worldGameState == GameState.Paused || worldGameState == GameState.MainMenu)
            {
                menuManager.Draw(spriteBatch);
            }
            else if (worldGameState == GameState.GameOver)
            {
                // Handle Game Over state (example: display "Game Over" text)
                spriteBatch.DrawString(content.Load<SpriteFont>("Font"), "Game Over!", new Vector2(100, 100), Color.Red);
            }
        }
        private Vector2 GetPlayerInput()
        {
            Vector2 movement = Vector2.Zero;

            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.W))
            {
                movement.Y -= 1.0f;
            }
            if (keyboard.IsKeyDown(Keys.S))
            {
                movement.Y += 1.0f;
            }
            if (keyboard.IsKeyDown(Keys.A))
            {
                movement.X -= 1.0f;
            }
            if (keyboard.IsKeyDown(Keys.D))
            {
                movement.X += 1.0f;
            }
            return movement;
        }

        // Assuming you have a method to create your game menu items
        private List<MenuItem> CreateGameMenuItems()
        {
            List<MenuItem> menuItems = new List<MenuItem>();
            // Add your desired menu options here
            // Example:
            menuItems.Add(new MenuItem("Resume"));
            menuItems.Add(new MenuItem("Exit"));
            return menuItems;
        }
        public Player Player { get; set; } // Public property for the player
                                           // ... other class members ...
    }
}
