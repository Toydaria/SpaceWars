using System.Linq;
using System.Reflection;
using SpaceWars.Interfaces;
using SpaceWars.Model;

namespace SpaceWars.GameObjects
{
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Content;
    using AsteroidsPack;

    public class Bullet: GameObject
    {

        private static readonly Vector2 UP = new Vector2(0, -30);
        private const int LeftCorner = 0;
        private const int RightCorner = 700;
        private const int UpCorner = 0;
        private const int DownCorner = 1000;
        

        public Bullet(Vector2 position)
        {
<<<<<<< HEAD
            Speed = UP;
            Position = position;
            BoundingBox = new Rectangle((int)position.X,(int)position.Y, 5, 5);
=======
            texture = null;
            speed = 15;
            isVisible = false;
            Damage = 30;//TODO: hardcoded value to change
>>>>>>> 0c4448ba661d6cf429691f3cabc5a0374de6390f
        }

        public override void Intersect(IGameObject obj)
        {
            //if (obj.GetType() == typeof(ChunkyAsteroid))
            //{
            //    ChunkyAsteroid asteroid = (ChunkyAsteroid)obj;
            //    Owner.RemoveObject(asteroid);
            //    Owner.RemoveObject(this);
            //}
            if (obj is IAsteroid)
            {
                var asteroid = (Asteroid) obj;
                Owner.RemoveObject(asteroid);
                Owner.RemoveObject(this);
            }

        }

        public override void LoadContent(ResourceManager resourceManager)
        {
            Texture = resourceManager.GetResource("laser");
        }

        public override void Think(GameTime gameTime)
        {
            bool needToRemove = false;

            if (Position.X < LeftCorner)
                needToRemove = true;
            if (Position.X > RightCorner)
                needToRemove = true;
            if (Position.Y > DownCorner)
                needToRemove = true;
            if (Position.Y < UpCorner)
                needToRemove = true;

            if (needToRemove)
                Owner.RemoveObject(this);
        }




        

    }
}
