using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace SpaceWars.GameObjects.AsteroidsPack
{
    class ChunkyAsteroid : Asteroid
    {
        private const int ChunkyAsteroidDamage = 30;

        public ChunkyAsteroid(ContentManager content) : base(content, "chunky", new Vector2(randomPicker.Next(0, 780), -50), new Vector2(0, 5), ChunkyAsteroidDamage)
        {
        }

    }
}
