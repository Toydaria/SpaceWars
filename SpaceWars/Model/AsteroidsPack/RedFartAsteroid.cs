using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using SpaceWars.Interfaces;
using SpaceWars.Model;

namespace SpaceWars.GameObjects.AsteroidsPack
{
    class RedFartAsteroid : Asteroid
    {
        private new const int TextureWidth = 42;
        private new const int TextureHeight = 42;
        private new const int MinXVelocity = -2;
        private new const int MaxXVelocity = 3;
        private new const int MinYVelocity = -3;
        private new const int MaxYVelocity = 3;
        /// <summary>
        /// TODO hardcoded damage 
        /// </summary>
        private new const int damage = 20;

        public RedFartAsteroid()
        {
            Random rand = new Random();

            Position = new Vector2(rand.Next(LeftCorner, RightCorner), UpCorner);
            Speed = new Vector2(rand.Next(MinXVelocity, MaxXVelocity), rand.Next(MinYVelocity, MaxYVelocity));

            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, TextureWidth, TextureHeight);
        }

        public override void Intersect(IGameObject obj)
        {
            if (obj.GetType() == typeof(Player))
            {
                Player player = (Player)obj;
                // make dmg to player
            }
        }

        public override void LoadContent(ResourceManager resourceManager)
        {
            Texture = resourceManager.GetResource("redfart");
        }

    }
}
