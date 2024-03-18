using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TopDownShooter
{
    public class MenuManager
    {
        private List<MenuItem> menuItems;
        private int selectedIndex;
        private SpriteFont font;  // Add a member variable to store the font

        // Use a more descriptive name for menu state (e.g., MenuState)
        private MenuState menuState;

        public MenuManager(List<MenuItem> menuItems, ContentManager content, World.GameState initialState)
        {
            this.menuItems = menuItems;
            selectedIndex = 0;
            font = content.Load<SpriteFont>("2d\\Misc\\Arial16");

            // Ensure the initial state is compatible with MenuState
            menuState = (MenuState)initialState; // Assuming MenuState has the same values as World.GameState
        }

        public void Update(GameTime gameTime)
        {
            if (menuState == MenuState.Paused || menuState == MenuState.MainMenu)
            {
                // Handle keyboard input for menu navigation
                var keyboardState = Keyboard.GetState();

                if (keyboardState.IsKeyDown(Keys.Down) && selectedIndex < menuItems.Count - 1)
                {
                    selectedIndex++;
                }
                else if (keyboardState.IsKeyDown(Keys.Up) && selectedIndex > 0)
                {
                    selectedIndex--;
                }

                // ... (Add additional input handling as needed, e.g., Enter key to select)
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (menuState == MenuState.Paused || menuState == MenuState.MainMenu)
            {
                // ... (Menu drawing logic)
                for (int i = 0; i < menuItems.Count; i++)
                {
                    string menuItemText = menuItems[i].GetText();
                    Vector2 menuItemPosition = new Vector2(100, 100 + i * 30); // Adjust positioning as needed
                    Color menuItemColor = Color.White;
                    if (i == selectedIndex)
                    {
                        menuItemColor = Color.Yellow; // Highlight selected option
                    }
                    spriteBatch.DrawString(font, menuItemText, menuItemPosition, menuItemColor);
                }
            }
        }

        public bool IsSelected(string menuItemName)
        {
            return menuItems[selectedIndex].GetText() == menuItemName;
        }

        public void ResetSelection()
        {
            selectedIndex = 0;
        }
    }

    public enum MenuState  // Assuming this is defined elsewhere
    {
        Playing,
        Paused,
        MainMenu
    }
}
