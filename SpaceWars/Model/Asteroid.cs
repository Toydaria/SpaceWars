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
        protected const int TextureWidth = 38; 
        protected const int TextureHeight = 38; 
        protected const int UpCorner = - TextureWidth; // asteroid size
        protected const int RightCorner = 800 - TextureWidth; // Screen width - asteroid width
        protected const int DownCorner = 950 - TextureHeight; // Screen height - asteroid height
        protected const int LeftCorner = 0;
        protected const int MinXVelocity = -12;
        protected const int MaxXVelocity = 12;
        protected const int MinYVelocity = -9;
        protected const int MaxYVelocity = 9;
        protected int damage;
        protected static Random rand = new Random();
        protected Vector2 origin;
        protected float rotationAngle = rand.Next(0, 180);

        public Asteroid(int damage)
        {
            Random rand = new Random();

            this.Damage = damage;
            Position = new Vector2(rand.Next(LeftCorner, RightCorner), UpCorner);
            Speed = new Vector2(rand.Next(MinXVelocity, MaxXVelocity), rand.Next(MinYVelocity, MaxYVelocity));
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, TextureWidth, TextureHeight);
        }

        public int Damage { get; private set; }

        public override void Intersect(IGameObject obj)
        {
            if (obj.GetType() == typeof(Player))
            {
                Player player = (Player)obj;
                player.TakeDMG(this.Damage);
                Owner.RemoveObject(this);
            }
        }
        
        public override void LoadContent(ResourceManager resourceManager)
        {
            Texture = resourceManager.GetResource("asteroid");
        }

        public override void Think(GameTime gameTime)
        {
            bool needToRemove = false;

            if (Position.Y > DownCorner + TextureHeight) // asteroid size
            {
                needToRemove = true;
            }
            if (Position.X < LeftCorner - TextureWidth) // asteroid size
            {
                needToRemove = true;
            }
            if (Position.X > RightCorner + TextureWidth) // asteroid size
            {
                needToRemove = true;
            }
            if (Position.Y < UpCorner) // asteroid size
            {
                needToRemove = true;
            }
            Rotate(gameTime);
            if (needToRemove)
            {
                Owner.RemoveObject(this);
            }

            origin.X = Texture.Width / 2f;
            origin.Y = Texture.Height / 2f;
        }

        private void Rotate(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            rotationAngle += elapsed;
            float cirlce = MathHelper.Pi * 2;
            rotationAngle = rotationAngle % cirlce;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, rotationAngle, origin, 1.0f, SpriteEffects.None, 0f);
        }
    }       
}
