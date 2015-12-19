using SpaceWars.GameObjects.AsteroidsPack;
using SpaceWars.Model.Bonuses;

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
       // Asteroids asteroid = new Asteroids();
        ObjectManager objectManager = new ObjectManager();

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            bakcground.LoadContent(Content);
            objectManager.LoadContent(Content);
            objectManager.AddObject(player);
            base.LoadContent(Content);
        }

        public override void UnloadContent()
        {
            bakcground.UnloadContet();
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            objectManager.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            bakcground.Draw(spriteBatch);
            objectManager.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }
    }
}