using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceWars.Interfaces;
using SpaceWars.Model;

namespace SpaceWars.GameObjects
{
    public abstract class Asteroid : GameObject, IAsteroid
    {
        protected Texture2D image;
        protected Rectangle sourceRectangle;
        protected string asset;
        protected Vector2 position;
        protected Vector2 velocity;
        protected int damage;
        protected static Random randomPicker = new Random();

        public Asteroid(ContentManager content, string asset, Vector2 position, Vector2 velocity, int damage)
        {
            this.Image = content.Load<Texture2D>(asset);
            this.Position = position;
            this.Velocity = velocity;
            this.Damage = damage;
        }

        public Texture2D Image { get; set; }

        public Vector2 Position { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        //public Rectangle SourceRectangle { get; set;}
        public Vector2 Velocity { get; set; }

        public Rectangle SourceRectangle{ get; set; }


        public void Explode()
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Image, Position, Color.White);
        }


    }       
}
