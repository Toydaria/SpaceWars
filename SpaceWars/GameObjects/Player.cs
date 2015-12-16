using SpaceWars.Interfaces;
using SpaceWars.Model;

namespace SpaceWars.GameObjects
{
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using SpaceWars;

    public class Player: GameObject
    {
        private static readonly Vector2 UP = new Vector2(0, -10);
        private static readonly Vector2 DOWN = new Vector2(0, 10);
        private static readonly Vector2 LEFT = new Vector2(-10,0);
        private static readonly Vector2 RIGHT = new Vector2(10,0);
        private static readonly Vector2 ZERO = new Vector2(0, 0);
        private const int LeftCorner = 0;
        private const int RightCorner = 800 - 64; // Screen width - ship width
        private const int UpCorner = 0;
        private const int DownCorner = 950 - 64; // Screen height - ship height
        private const int ShootInterval = 120;


        private Vector2 upTemp;
        private Vector2 downTemp;
        private Vector2 leftTemp;
        private Vector2 rightTemp;


        private Stringer Text = new Stringer(new Vector2(100, 100));


        private int health;
        private int damage;
        private int elapsedShootTime = 0;
        
        

        public Player()
        {
            Texture = null;
            Position = new Vector2(350, 890);
            this.BoundingBox = new Rectangle(350, 890, 64, 64);
            Speed = new Vector2(0,0);
            Health = 100;//TODO: hardcoded value to change
            Damage = 100;//TODO: hardcoded value to change
        }

        public int Health
        {
            get { return this.health; }

            set
            {
                if (value < 0)
                {
                    this.health = 0;
                }
                this.health = value;
            }
        }
        public int Damage { get; set; }
        public int Shield { get; set; }

        public override void LoadContent(ResourceManager resourceManager)
        {
            Text.LoadContent(resourceManager);
            Texture = resourceManager.GetResource("ship");
        }

        

        public override void Think(GameTime gameTime)
        {
            //Getting the keyboardState
            KeyboardState keyboard = Keyboard.GetState();

            this.BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);

            //Draw Text
            Text.Text = "Health: " + Health;

            //Player Controls
            if (keyboard.IsKeyDown(Keys.A) && Position.X > LeftCorner)
            {
                leftTemp = LEFT;
            }
            else
            {
                leftTemp = ZERO;
            }

            if (keyboard.IsKeyDown(Keys.D) && Position.X < RightCorner)
            {
                rightTemp = RIGHT;
            }
            else
            {
                rightTemp = ZERO;
            }

            if (keyboard.IsKeyDown(Keys.W) && Position.Y > UpCorner)
            {
                upTemp = UP;
            }
            else
            {
                upTemp = ZERO;
            }

            if (keyboard.IsKeyDown(Keys.S) && Position.Y < DownCorner)
            {
                downTemp = DOWN;
            }
            else
            {
                downTemp = ZERO;
            }

            Speed = leftTemp + rightTemp + upTemp + downTemp;

            elapsedShootTime += gameTime.ElapsedGameTime.Milliseconds;

            if (keyboard.IsKeyDown(Keys.Space) && elapsedShootTime > ShootInterval)
            {
                elapsedShootTime = 0;
                Shoot();
            }
  
        }

        public override void Intersect(IGameObject obj)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Text.Draw(spriteBatch);
            spriteBatch.Draw(Texture, Position, Color.White);
        }

        void Shoot()
        {
            Owner.AddObject(new Bullet(Position));
        }
    }

    
}