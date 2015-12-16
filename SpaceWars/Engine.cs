using SpaceWars.Model;

namespace SpaceWars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Xna.Framework;

    using Screens.ScreenManagement;

    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.GamerServices;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Media;


    public class Engine : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Engine()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        // Game Enemy
        List<Enemy> enemies = new List<Enemy>();
        Random random = new Random();



        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = (int)ScreenManager.Instance.Dimensions.X;
            graphics.PreferredBackBufferHeight = (int)ScreenManager.Instance.Dimensions.Y;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ScreenManager.Instance.Engine = this;
            ScreenManager.Instance.GraphicsDevice = GraphicsDevice;
            ScreenManager.Instance.SpriteBatch = spriteBatch;
            ScreenManager.Instance.LoadContent(Content);
        }


        protected override void UnloadContent()
        {
            ScreenManager.Instance.UnloadContent();
        }

        float spawn = 0;
        protected override void Update(GameTime gameTime)
        {
            spawn += (float) gameTime.ElapsedGameTime.TotalSeconds;
            foreach (Enemy enemy in enemies)
            {
                enemy.Update(graphics.GraphicsDevice);
            }
            //Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            ScreenManager.Instance.Update(gameTime);
            base.Update(gameTime);
        }

        public void LoadEnemies()
        {
            int randY = random.Next(100, 400);

            if (spawn >= 1)
            {
                spawn = 0;
                if (enemies.Count() < 4)
                {
                    enemies.Add(new Enemy(Content.Load<Texture2D>("ship"),new Vector2(60, randY)));
                }
            }

            for (int i = 0; i < enemies.Count; i++)
            {
                if (!enemies[i].isVisible)
                {
                    enemies.RemoveAt(i);
                    i--;
                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            ScreenManager.Instance.Draw(spriteBatch);
            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
