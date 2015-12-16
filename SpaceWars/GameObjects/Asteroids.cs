namespace SpaceWars.GameObjects
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class Asteroids
    {
        public Rectangle boundingBox;
        private Texture2D texture;
        private Vector2 position;
        private Vector2 origin;
        private float rotationAngle;
        private int speed;

        public List<Asteroids> asteroidList = new List<Asteroids>();
        public float randX, randY;
        public bool isVisible;
        Random random = new Random();

        public Asteroids(Vector2 newPosition, Texture2D newTexture)
        {
            texture = newTexture;
            position = newPosition;
            speed = 4;
            isVisible = true;
            randX = random.Next(0, 750);
            randY = random.Next(-600, -50);
        }

        public Asteroids()
        {
        }
        
        //Load Content
        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("asteroid");
        }

        public void UnloadContent()
        {
        }

        //Update
        public void Update(GameTime gameTime)
        {
            //Set bounding box for collision
            boundingBox = new Rectangle((int)position.X, (int)position.Y, 10, 45);
            
            // Update Movement
            position.Y = position.Y + speed;
            if (position.Y >= 950)
            {
                position.Y = -50;
            }

            //Setting Origin for rotating
            origin.X = texture.Width / 2;
            origin.Y = texture.Height / 2;

            // Rotate Asteroid
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            rotationAngle += elapsed;
            float cirlce = MathHelper.Pi * 2;
            rotationAngle = rotationAngle % cirlce;

            LoadAsteroids();
        }

        //Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Asteroids a in asteroidList)
            {
                if (a.isVisible)
                {
                    spriteBatch.Draw(a.texture, a.position, null, Color.White, a.rotationAngle, a.origin, 1.0f, SpriteEffects.None, 0f);
                }
            }
        }

        public void LoadAsteroids()
        {
            int randY = random.Next(-600, -50);
            int randX = random.Next(0, 750);

            if (asteroidList.Count < 10)
            {
                asteroidList.Add(new Asteroids(new Vector2(randX, randY), this.texture));
            }

            for (int i = 0; i < asteroidList.Count; i++)
            {
                if (!asteroidList[i].isVisible)
                {
                    asteroidList.RemoveAt(i);
                    i--;
                }

            }
        }
    }
}