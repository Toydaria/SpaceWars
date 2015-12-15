using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace SpaceWars.GameObjects.AsteroidsPack
{
    class RockyAsteroid : Asteroid
    {
        private const int RockyAsteroidDamage = 40;

        public RockyAsteroid(ContentManager content) : base(content, "rocky", new Vector2(randomPicker.Next(0, 780), -50), new Vector2(0, 6), RockyAsteroidDamage)
        {
        }
    }
}
