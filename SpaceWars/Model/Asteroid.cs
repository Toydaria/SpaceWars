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
        protected static Random randomPicker = new Random();
        protected float rotationAngle = randomPicker.Next(0, 180);
        protected Vector2 origin;

        protected Asteroid(ContentManager content, string asset, Vector2 position, Vector2 speed, int damage)
        {
            this.Texture = content.Load<Texture2D>(asset);
            this.Position = position;
            this.Speed = speed;
            this.Damage = damage;
        }

        public int Health { get; set; }
        public string Asset { get; protected set; }
        public int Damage { get; set; }
        public Vector2 Origin { get; set; }
       
        public virtual void LoadContent(ContentManager content)
        {
            this.Texture = content.Load<Texture2D>(this.Asset);
        }

        public void Update(GameTime gameTime)
        {
            Think(gameTime);
            Move();
            //check for collision??
        }

        public void Move()
        {
            this.Position += this.Speed;
        }

        public void Think(GameTime gameTime)
        {
            Rotate(gameTime);
        }

        protected void Rotate(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            rotationAngle += elapsed;
            float cirlce = MathHelper.Pi * 2;
            rotationAngle = rotationAngle % cirlce;
        }

        //public void Intersect(Player player)
        //{
        //    this.BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, this.Texture.Width, this.Texture.Height);
        //    if (this.BoundingBox.Intersects(player.BoundingBox))
        //    {
        //        this.Intersect(player);
        //        player.Health -= this.Damage;
        //    }
        //    //TODO: not implemented
        //}

        public void Draw(SpriteBatch spriteBatch)
        {
            origin.X = Texture.Width / 2f;
            origin.Y = Texture.Height / 2f;
            spriteBatch.Draw(Texture, Position, null, Color.White, rotationAngle, origin, 1.0f, SpriteEffects.None, 0f);
        }


    }       
}
