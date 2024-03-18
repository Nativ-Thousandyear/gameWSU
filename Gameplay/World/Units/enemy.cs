using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using TopDownShooter.Source.Gameplay.World.Units;

namespace TopDownShooter
{
    public class Enemy : Unit
    {
        public int bulletsPerEnrageWave, millisecondsBetweenEnrageWaves;
        public McTimer enrageTimer, enrageWaveTimer;
        private int currentRoutePointIndex = 0;
        public bool IsActive { get; set; }
        private Vector2 velocity; // Consider removing if using route for movement
        public bool IsAlive { get; private set; }

        public delegate void EnemyHitHandler(Enemy enemy);
        public event EnemyHitHandler EnemyHit;
        private TimeSpan shootingInterval;
        private TimeSpan lastShootingTime;
        public bool isBoss;
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }

        // Add Hit property
        public bool Hit { get; private set; }

        public Enemy(Texture2D sprite, Vector2 position, Vector2 velocity, Route route, GameTime gameTime, bool isBoss)
            : base(sprite, position, new Vector2(sprite.Width, sprite.Height), route)
        {
            pos = position;
            // Consider using route for movement if provided
            // this.velocity = velocity;
            this.route = route;
            this.IsActive = true;
            this.IsAlive = true;
            this.Hit = false; // Initialize Hit to false
            this.shootingInterval = TimeSpan.FromSeconds(5);
            this.lastShootingTime = gameTime.TotalGameTime;
            enrageTimer = new McTimer(5000);
            enrageWaveTimer = new McTimer(0);
            millisecondsBetweenEnrageWaves = 500;
            bulletsPerEnrageWave = 20;
            this.isBoss = isBoss;
        }

        public override void OnHit(float damage)
        {
            this.IsAlive = false;
            this.IsActive = false;
            this.Hit = true; // Set Hit to true when hit

            // Additional logic for when the enemy is hit can be added here
            // For example, playing a death animation, sound, or spawning particles
            EnemyHit?.Invoke(this);
        }

        public void Update(GameTime gameTime, Player player)
        {
            if (IsActive && route != null && route.routePoints.Count > 0)
            {
                RoutePoint currentPoint = route.routePoints[0];
                if (IsAtPoint(pos, currentPoint.point))
                {
                    route.routePoints.RemoveAt(0);
                    if (route.routePoints.Count == 0)
                    {
                        IsActive = false; // Deactivate if the route is completed
                        return;
                    }
                }
                else
                {
                    Vector2 direction = currentPoint.point - pos;
                    direction.Normalize(); // Ensure the direction is normalized
                    float speed = currentPoint.speed; // Use the speed defined in the route point
                    pos += direction * speed;
                }
            }
            // Consider removing if using route for movement
            // else
            // {
            //     pos += velocity * gameTime.ElapsedGameTime.Milliseconds / 1000.0f;
            // }

            // Check screen bounds
            if (pos.X < 0 || pos.Y < 0 || pos.X > Globals.screenWidth || pos.Y > Globals.screenHeight)
            {
                IsActive = false;
            }

            // Check collision with hero
            if (Globals.GetDistance(pos, player.pos) < 15)
            {
                player.OnHit(1);
                IsActive = false;
                IsAlive = false;
                Hit = true; // Set Hit to true when hit
            }

            // Enemy shooting
            if (gameTime.TotalGameTime - this.lastShootingTime > this.shootingInterval)
            {
                // Shoot a fireball
                Vector2 fireballPosition = new Vector2(pos.X + 40, pos.Y + 40);
                Vector2 targetPosition = new Vector2(player.pos.X, player.pos.Y);
                Texture2D enemyFireball_sprite = GameGlobals.spriteHandler.get_EnemyFireball_Sprite();
                GameGlobals.PassProjectile(new Fireball(enemyFireball_sprite, fireballPosition, this, targetPosition));
                lastShootingTime = gameTime.TotalGameTime;

            }


            // Enrage
            enrageTimer.UpdateTimer();
            enrageWaveTimer.UpdateTimer();
        }
    }
}
