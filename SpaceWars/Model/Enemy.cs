//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using SpaceWars.GameObjects;

//namespace SpaceWars.Model
//{
//    public class Enemy : GameObject
//    {
//        private Texture2D texture;
//        public Bullet bullet = new Bullet();
//        public Vector2 position;
//        public Vector2 velocity;

//        public bool isVisible = true;

//        Random random = new Random();

//        DateTime second = new DateTime();

//        int randX, randY;


//        public Enemy(Texture2D newTexture, Vector2 newPosition)
//        {
//            texture = newTexture;
//            position = newPosition;

//            randY = random.Next(-4, 4);
//            randX = random.Next(-4, -1);

//            velocity = new Vector2(randX, randY);
//        }

//        public void Update(GraphicsDevice graphics)
//        {
//            position += velocity;

//            if (position.Y <= 0 || position.Y >= graphics.Viewport.Height - texture.Height)
//            {
//                velocity.Y = -velocity.Y;
//            }

//            if (position.X < 0 - texture.Width)
//            {
//                isVisible = false;
//            }
//            if (random.Next(second.Second) > 5)
//            {
//                bullet.Shoot();
//            }
//            bullet.UpdateBullets();
//        }

//        public void Drow(SpriteBatch spriteBatch)
//        {
//            spriteBatch.Draw(texture,position,Color.White);
//            bullet.Draw(spriteBatch);
//        }
//    }
//}
