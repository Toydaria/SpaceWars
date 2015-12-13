namespace SpaceWars.GameObjects
{
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class Player
    {
        private Texture2D texture;
        private float speed;
        public Bullet bullet = new Bullet();
        private int health;
        private int damage;
        public static Vector2 position;
        public Rectangle boundingBox;

        public Player()
        {
            texture = null;
            position = new Vector2(350, 890);
            speed = 10;
            Health = 100;//TODO: hardcoded value to change
            Damage = 100;//TODO: hardcoded value to change
        }

        public int Health { get; set; }
        public int Damage { get; set; }
        public void LoadContent(ContentManager Content)
        {
            bullet.LoadContent(Content);
            texture = Content.Load<Texture2D>("ship");
        }

        public void UnloadContent()
        {
        }

        public void Update(GameTime gameTime)
        {
            //Getting the keyboardState
            KeyboardState keyboard = Keyboard.GetState();

            //Player Controls
            if (keyboard.IsKeyDown(Keys.A) && position.X - speed > -10)
            {
                position.X -= speed;
            }

            if (keyboard.IsKeyDown(Keys.D) && position.X + speed < GraphicsDeviceManager.DefaultBackBufferWidth - 54)
            {
                position.X += speed;
            }

            if (keyboard.IsKeyDown(Keys.W) && position.Y - speed > 0)
            {
                position.Y -= speed;
            }

            if (keyboard.IsKeyDown(Keys.S) && position.Y + speed < 900)
            {
                position.Y += speed;
            }

            if (keyboard.IsKeyDown(Keys.Space))
            {
                bullet.Shoot();
            }

            //Bullets Controls
            if (keyboard.IsKeyDown(Keys.Space))
            {
                bullet.Shoot();
            }

            bullet.UpdateBullets();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
            bullet.Draw(spriteBatch);
        }
    }
}