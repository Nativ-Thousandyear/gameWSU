using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TopDownShooter
{
    public class OptionsMenu : MenuItem
    {
        private bool _isVisible;
        private List<MenuItem> _menuItems;

        public OptionsMenu(ContentManager content)
        {
            _isVisible = false;
            _menuItems = new List<MenuItem>();

            // Add options to the menu (example) with text arguments
            _menuItems.Add(new OptionMenuItem("Difficulty: Easy", content));
            _menuItems.Add(new OptionMenuItem("Sound Volume: 50%", content));
            _menuItems.Add(new OptionMenuItem("Back", content)); // Option to return to MainMenu
        }

        public string GetText() // Add 'override' keyword
        {
            return "Settings"; // Text displayed for the OptionsMenu in the main menu
        }

       

        public override void Select()
        {
            _isVisible = !_isVisible; // Toggle visibility on selection
        }

        public void Show()
        {
            _isVisible = true; // Manually show the options menu
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            if (_isVisible)
            {
                // Draw menu options logic using spriteBatch and font (implementation needed)
                // Iterate through _menuItems and draw their text with positioning and selection highlighting
            }
        }
    }
}
