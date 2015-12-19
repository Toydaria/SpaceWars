﻿namespace SpaceWars.Screens
{
    using SpaceWars.Screens.ScreenManagement;
    using SpaceWars.GameObjects;

    using Microsoft.Xna.Framework.Input;

    public class SplashScreen : GameScreen
    {
        Starfield Background = new Starfield();
        Image Image = new Image("startBackground");

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            Background.LoadContent(Content);
            Image.LoadConent(Content);

            base.LoadContent(Content);
        }

        public override void UnloadContent()
        {
            Background.UnloadContet();
            Image.UnloadContent();

            base.UnloadContent();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            Background.Update(gameTime);

            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Escape))
            {
                ScreenManager.Instance.Engine.Exit();
            }
            if (keyboard.IsKeyDown(Keys.Enter))
            {
                ScreenManager.Instance.ChangeScreen("MainScreen");
            }
            //if (keyboard.IsKeyDown(Keys.H))
            //{
            //    ScreenManager.Instance.ChangeScreen("HighScore");
            //}
            base.Update(gameTime);
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            Background.Draw(spriteBatch);
            Image.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }
    }
}
