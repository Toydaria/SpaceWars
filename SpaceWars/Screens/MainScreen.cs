namespace SpaceWars.Screens
{
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using GameObjects;
    using ScreenManagement;

    public class MainScreen : GameScreen
    {
        Starfield bakcground = new Starfield();
        Player player = new Player();
        Asteroids asteroid = new Asteroids();

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            bakcground.LoadContent(Content);
            asteroid.LoadContent(Content);
            player.LoadContent(Content);
            base.LoadContent(Content);
        }

        public override void UnloadContent()
        {
            bakcground.UnloadContet();
            asteroid.UnloadContent();
            player.UnloadContent();
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            //Update Asteroids
            foreach (Asteroids a in asteroid.asteroidList)
            {
                //Check for collision between playership and asteroids
                if (a.boundingBox.Intersects(player.boundingBox))
                {
                    a.isVisible = false;
                }

                //Check for collision between bullets  and asteroids
                for (int i = 0; i < player.bullet.bulletList.Count; i++)
                {
                    if (a.boundingBox.Intersects(player.bullet.bulletList[i].boundingBox))
                    {
                        a.isVisible = false;
                        player.bullet.bulletList[i].isVisible = false;
                        //score++;
                    }
                }
                a.Update(gameTime);
            }
            asteroid.Update(gameTime);
            bakcground.Update(gameTime);
            player.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            bakcground.Draw(spriteBatch);
            player.Draw(spriteBatch);
            asteroid.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }
    }
}