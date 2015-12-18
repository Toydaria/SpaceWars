﻿using SpaceWars.Interfaces;
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
        //Stefka: cropped the png of the laser and added TextureWidth and TextureHight = 64(the size of the png) and changed the values in the constructor, because they were 5 X 5 - the reason why asteroids were shot only from the right
        private const int TextureWidth = 64;
        private const int TextureHeight = 64; 

        private static readonly Vector2 UP = new Vector2(0, -30);
        private const int LeftCorner = 0;
        private const int RightCorner = 800;
        private const int UpCorner = 0;
        private const int DownCorner = 950;
        

        public Bullet(Vector2 position)
        {
            Speed = UP;
            Position = position;
            BoundingBox = new Rectangle((int)position.X,(int)position.Y, TextureWidth, TextureHeight);
        }

        public override void Intersect(IGameObject obj)
        {
            if (obj is IAsteroid)
            {
                var asteroid = (Asteroid)obj;
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
