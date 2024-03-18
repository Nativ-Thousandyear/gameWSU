using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace TopDownShooter
{
    public class OptionMenuItem : MenuItem
    {
        private string _settingValue; // Example: Difficulty level, sound volume percentage

        public OptionMenuItem(string text, ContentManager content) : base(text)
        {
            // Parse or store the setting value from the text (implementation needed)
            _settingValue = text.Split(':')[1].Trim(); // Example parsing
        }

        public override void Select()
        {
            // Handle selection logic specific to this option (e.g., change difficulty, adjust sound volume)
            Console.WriteLine("Option selected: " + GetText()); // Example
        }

        // Getter method for the setting value (optional)
        public string GetSettingValue()
        {
            return _settingValue;
        }
    }
}