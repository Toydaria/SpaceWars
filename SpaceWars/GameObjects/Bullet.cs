namespace SpaceWars.GameObjects
{
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Content;

    public class Bullet
    {
        private Texture2D texture;
        private Vector2 origin;
        private float speed;
        private int bulletDelay = 20;
        private int damage;
        private int bulletsCount;
        
        public Rectangle boundingBox;
        public bool isVisible;
        public List<Bullet> bulletList = new List<Bullet>();
        public Vector2 position;
        

        //Constructer
        public Bullet()
        {
            texture = null;
            speed = 10;
            isVisible = false;
            Damage = 30;//TODO: hardcoded value to change
        }

        public int Damage { get; set; }


        //LoadContent
        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("laser");
        }

        //UnloadContent
        public void UnloadContent()
        {
        }

        //Update
        public void Update(GameTime gameTime)
        {
            
        }

        //Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Bullet bullet in bulletList)
            {
                spriteBatch.Draw(bullet.texture, bullet.position, Color.White);
            }
        }

        //Shoot Method: Set the bullet position infront of the ship
        public void Shoot()
        {
            if (bulletDelay >= 0)
            {
                bulletDelay--;
            }

            if (bulletDelay <= 0)
            {
                Bullet newBullet = new Bullet();
                newBullet.texture = this.texture;
                newBullet.position = new Vector2(Player.position.X + 32 - newBullet.texture.Width / 2, Player.position.Y + 30);
                newBullet.isVisible = true;

                
                if (bulletList.Count < 20)
                {
                    bulletList.Add(newBullet);
                    bulletsCount--;
                }
            }

            //Set bulletDelay back
            if (bulletDelay <= 0)
            {
                bulletDelay = 20;
            }
        }

        //Update bullet function
        public void UpdateBullets()
        {
            foreach (Bullet b in bulletList)
            {
                b.boundingBox = new Rectangle((int)b.position.X, (int)b.position.Y, b.texture.Width, b.texture.Height);
                b.position.Y = b.position.Y - b.speed;

                if (b.position.Y <= 0)
                {
                    b.isVisible = false;
                }
            }

            for (int i = 0; i < bulletList.Count; i++)
            {
                if (!bulletList[i].isVisible)
                {
                    bulletList.RemoveAt(i);
                    i--;

                }
            }
        }
    }
}
