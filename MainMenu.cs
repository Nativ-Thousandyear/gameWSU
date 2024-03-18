using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace TopDownShooter.Source
{
    public class MainMenu : MenuItem
    {
        private readonly ContentManager _content;
        private OptionsMenu _optionsMenu;

        public MainMenu(string text, ContentManager content) : base(text)
        {
            _content = content;
            _optionsMenu = new OptionsMenu(_content);
        }

        public override void Select()
        {
            // Option 1: Directly start the game (commented out)
            // World.gameState = GameState.Playing;
            // ... (Load initial game content)

            // Option 2: Show options menu before starting
            _optionsMenu.Show();
        }

        public event Action<MainMenu> OnMenuSelected; // Event for menu selection (optional)
    }
}
