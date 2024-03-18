#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using TopDownShooter;
#endregion

namespace TopDownShooter
{
    public class Boss_L1_Fireball : Projectile2d
    {

        public Boss_L1_Fireball(Texture2D texture, Vector2 pos, Unit owner, Vector2 target)
        : base(texture, pos, new Vector2(30, 30), owner, target)
        {

        }

        public override void Update(Vector2 OFFSET, List<Unit> UNITS)
        {
            base.Update(OFFSET, UNITS);
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
