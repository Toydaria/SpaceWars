namespace SpaceWars.Screens
{
    using SpaceWars.Screens.ScreenManagement;
    using GameObjects;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework;

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
            //Controls
            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Escape))
            {
                ScreenManager.Instance.Engine.Exit();
            }
            if (keyboard.IsKeyDown(Keys.Enter))
            {
                ScreenManager.Instance.ChangeScreen("SplashScreen");
            }
            //if (keyboard.IsKeyDown(Keys.H))
            //{
            //    ScreenManager.Instance.ChangeScreen("HighScore");
            //}

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
