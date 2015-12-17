using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using SpaceWars.Interfaces;

namespace SpaceWars.GameObjects.AsteroidsPack
{
    class RockyAsteroid : Asteroid
    {
        public RockyAsteroid(ContentManager content, string asset, Vector2 position, Vector2 velocity, int health, int damage) : base(content, "Sprites/rocky", new Vector2(randomPicker.Next(0, 800), -50), new Vector2(0, 2), 40)
        { 
        }

        public override void Intersect(IGameObject obj)
        {
            throw new NotImplementedException();
        }

        public override void LoadContent(ResourceManager resourceManager)
        {
            throw new NotImplementedException();
        }

        public override void Think(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
