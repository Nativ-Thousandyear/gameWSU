using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using TopDownShooter;

public class StandardEnemyFactory : IEnemyFactory
{
    private Texture2D impSprite;
    private Texture2D boss1Sprite;
    private Texture2D boss2Sprite;
    private Texture2D boss3Sprite;

    public StandardEnemyFactory(Texture2D impSprite, Texture2D boss1Sprite, Texture2D boss2Sprite, Texture2D boss3Sprite)
    {
        this.impSprite = impSprite;
        this.boss1Sprite = boss1Sprite;
        this.boss2Sprite = boss2Sprite;
        this.boss3Sprite = boss3Sprite;
    }

    public Enemy CreateImp(Vector2 position, Vector2 velocity, Route route, GameTime gameTime)
    {
        // Create and return the Enemy with the provided route
        return new Enemy(impSprite, position, velocity, route, gameTime, false);
    }

    public Enemy CreateL1Mob(Vector2 position, Vector2 velocity, Route route, int bossLevel, GameTime gameTime)
    {
        // Use provided route and boss level to customize the boss
        Texture2D sprite = boss1Sprite; // Choose sprite based on boss level
        return new Enemy(sprite, position, velocity, route, gameTime, true);
    }

    public Enemy CreateL2Boss(Vector2 position, Vector2 velocity, Route route, int bossLevel, GameTime gameTime)
    {
        // Use provided route and boss level to customize the boss
        Texture2D sprite = boss2Sprite; // Choose sprite based on boss level
        return new Enemy(sprite, position, velocity, route, gameTime, true);
    }

    public Enemy CreateL3Boss(Vector2 position, Vector2 velocity, Route route, int bossLevel, GameTime gameTime)
    {
        // Use provided route and boss level to customize the boss
        Texture2D sprite = boss3Sprite; // Choose sprite based on boss level
        return new Enemy(sprite, position, velocity, route, gameTime, true);
    }
}