using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace SpaceWars.GameObjects.AsteroidsPack
{
    class RedFartAsteroid : Asteroid
    {
        private const int RedFartAsteroidDamage = 60;

        public RedFartAsteroid(ContentManager content) : base(content, "redfart", new Vector2(randomPicker.Next(0, 780), -50), new Vector2(0, 6), RedFartAsteroidDamage)
        {
        }
    }
}
