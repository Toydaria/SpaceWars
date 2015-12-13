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

        public ChunkyAsteroid(ContentManager content): base (content, "Sprites/chunky", new Vector2(randomPicker.Next(0, 800), -50), new Vector2(0, 4),20)
        {
        }

        //public ChunkyAsteroid(ContentManager Content, string asset, Vector2 position, Vector2 velocity, int health, int damage) : base(Content, asset, position, velocity, health, damage)
        //  //:base(Content, new Vector2(-10, 1*randomPicker.Next(0, 620)), new Vector2(100, 0), 100, 50)
        //{
        //}

        //position => random
        //velocity => hardcoded 100, 0
        //damage => hardcoded 50
        //health => 100
    }
}
