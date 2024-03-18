using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

public class Timer
{
    private TimeSpan timeLeft;
    private SpriteFont font;
    private Vector2 position;
    private bool isRunning;
    private GraphicsDeviceManager graphics;

    public Timer(TimeSpan initialTime, SpriteFont font, GraphicsDeviceManager graphics)
    {
        this.timeLeft = initialTime;
        this.font = font;
        this.graphics = graphics;
        this.isRunning = false;
        UpdatePosition();
    }

    public double GetTimeLeftInSeconds()
    {
        return timeLeft.TotalSeconds;
    }

    private void UpdatePosition()
    {
        string timeText = timeLeft.ToString(@"mm\:ss");
        Vector2 size = font.MeasureString(timeText);
        position = new Vector2(graphics.PreferredBackBufferWidth - size.X - 10, 10);
    }

    public void Start() => isRunning = true;

    public void Stop() => isRunning = false;

    public void Reset(TimeSpan newTime)
    {
        timeLeft = newTime;
        isRunning = false;
        UpdatePosition();
    }

    public void Update(GameTime gameTime)
    {
        if (isRunning && timeLeft.TotalSeconds > 0)
        {
            timeLeft -= gameTime.ElapsedGameTime;
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        UpdatePosition(); // Update position each frame
        string timeText = timeLeft.ToString(@"mm\:ss");
        spriteBatch.DrawString(font, timeText, position, Color.White);
    }
}
