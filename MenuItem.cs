using System;
using Microsoft.Xna.Framework.Content;

namespace TopDownShooter
{
    public class MenuItem
    {
        private string text;

        public MenuItem(string text) // Constructor requiring text argument
        {
            this.text = text;
        }

        public virtual string GetText()
        {
            return text;
        }

        // OptionsMenu.cs (assuming MenuItem has a constructor MenuItem(string text))
        public OptionsMenu(ContentManager content) // Constructor, not a method (corrected)
        {
            // ... rest of your code for initializing the OptionsMenu object

            return; // Explicitly return, even though constructors don't produce output
        }



        public virtual void Select()
        {
            // Default implementation (can be overridden in subclasses)
            Console.WriteLine("Menu item selected: " + text);
        }
    }
}
