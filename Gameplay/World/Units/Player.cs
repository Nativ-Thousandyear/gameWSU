using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TopDownShooter.Source.Gameplay.World.Units
{
    public class Player : Unit // Inherit from the Unit class
    {
        public Texture2D Texture { get; private set; }
        public Vector2 Position { get; set; }
        private float speed;
        public int Health { get; set; } // Current health of the player
        public int MaxHealth { get; private set; } // Maximum health of the player

        public Player(Texture2D texture, Vector2 position, int maxHealth)
            : base(texture, position, new Vector2(texture.Width, texture.Height), new Route(new List<RoutePoint>())) // Pass an empty list
        {
            Texture = texture;
            Position = position;
            speed = speed;
            MaxHealth = maxHealth; // Set initial max health
            Health = maxHealth; // Set initial health to max
        }

        // In Unit class:
        public virtual void Update(GameTime gameTime, Vector2 inputDirection)
        {
            // Normalize input to prevent diagonal movement being faster
            inputDirection.Normalize();

            Position += inputDirection * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Implement boundary checking to prevent the player from going off-screen (optional)
            // ... (code to check and adjust position if needed)
        }
    }
}
