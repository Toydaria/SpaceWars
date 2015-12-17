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
    class ChunkyAsteroid : GameObject
    {

        private const int UpCorner = -45; // asteroid size
        private const int RightCorner = 800 - 45; // Screen width - asteroid width
        private const int DownCorner = 950 - 45; // Screen height - asteroid height
        private const int LeftCorner = 0;
        private const int MinXVelocity = -15;
        private const int MaxXVelocity = 15;
        private const int MinYVelocity = 5;
        private const int MaxYVelocity = 15;

        public ChunkyAsteroid()
        {
            Random rand = new Random();

            Position = new Vector2(rand.Next(LeftCorner, RightCorner), UpCorner);
            Speed = new Vector2(rand.Next(MinXVelocity, MaxXVelocity), rand.Next(MinYVelocity, MaxYVelocity));

            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, 45, 45);
        }

        public override void Intersect(IGameObject obj)
        {
            if (obj.GetType() == typeof(Player))
            {
                Player player = (Player)obj;
                player.TakeDMG(10);
                Owner.RemoveObject(this);
                // make dmg to player
            }
        }

        public override void LoadContent(ResourceManager resourceManager)
        {
            Texture = resourceManager.GetResource("asteroid");
        }

        public override void Think(GameTime gameTime)
        {
            bool needToRemove = false;

            if (Position.Y > DownCorner + 45)// asteroid size
                needToRemove = true;
            if (Position.X < LeftCorner - 45)// asteroid size
                needToRemove = true;
            if (Position.X > RightCorner + 45)// asteroid size
                needToRemove = true;
            if (Position.Y < UpCorner)// asteroid size
                needToRemove = true;

            if (needToRemove)
                Owner.RemoveObject(this);

        }
    }
}
