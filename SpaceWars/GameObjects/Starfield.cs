﻿namespace SpaceWars.GameObjects
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    using Screens.ScreenManagement;

    public class Starfield : GameScreen
    {
        public Texture2D texture;
        public Vector2 bgPos1, bgPos2;
        public int speed;

        //Constructor
        public Starfield()
        {
            texture = null;
            bgPos1 = new Vector2(0, 0);
            bgPos2 = new Vector2(0, -950);
            speed = 5;
        }

        //Load Content
        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("space");
        }

        //Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, bgPos1, Color.White);
            spriteBatch.Draw(texture, bgPos2, Color.White);
        }

        //Update
        public void Update(GameTime gameTime)
        {
            bgPos1.Y = bgPos1.Y + speed;
            bgPos2.Y = bgPos2.Y + speed;

            // Scrolling the background (Repeating)

            if (bgPos1.Y >= 950)
            {
                bgPos1.Y = 0;
                bgPos2.Y = -950;
            }
        }
    }
}
