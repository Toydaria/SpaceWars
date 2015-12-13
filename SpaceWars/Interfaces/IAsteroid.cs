using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceWars.Interfaces
{
    interface IAsteroid
    {
        Texture2D Image { get; set; }
        Vector2 Position { get; set; }
        Vector2 Velocity { get; set; }
        Rectangle SourceRectangle { get; set; }
        int Damage { get; set; }

        void Explode();
        void Draw(SpriteBatch spriteBatch);
    }
}
