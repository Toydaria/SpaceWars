namespace SpaceWars.Screens
{
    using SpaceWars.Screens.ScreenManagement;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using GameObjects;

    public class GameOverScreen : GameScreen
    {
        Starfield background = new Starfield();
        Image gameOverStats = new Image("Gameover");
        

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            background.LoadContent(Content);
            gameOverStats.LoadConent(Content);
            base.LoadContent(Content);
        }

        public override void UnloadContent()
        {
            background.UnloadContet();
            gameOverStats.UnloadContent();
            base.UnloadContent();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            background.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            gameOverStats.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }
    }
}
