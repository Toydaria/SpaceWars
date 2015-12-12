namespace SpaceWars.Screens.ScreenManagement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Xml;
    using GameObjects;
    using Screens;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class ScreenManager
    {
        private static ScreenManager instance;
        private XmlManager<GameScreen> xmlGameScreenManager;

        public Vector2 Dimensions { private set; get; }
        public ContentManager Content { private set; get; }
        public Engine Engine;

        GameScreen currentScreen, newScreen;
        public GraphicsDevice GraphicsDevice;
        public SpriteBatch SpriteBatch;

        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ScreenManager();

                return instance;
            }
        }

        //public void ChangeScreen(string screenName)
        //{
        //    newScreen = new TestMenu();
        //    xmlGameScreenManager = new XmlManager<GameScreen>();
        //    xmlGameScreenManager.Type = newScreen.Type;
        //    newScreen = xmlGameScreenManager.Load("Loads/" + screenName);
        //    currentScreen = newScreen;
        //    currentScreen.LoadContent(Content);
        //    //newScreen = (GameScreen)Activator.CreateInstance(Type.GetType("Toydaria.Screens." + screenName));
        //}


        public ScreenManager()
        {
            Dimensions = new Vector2(800, 950);
            currentScreen = new MainScreen();
            xmlGameScreenManager = new XmlManager<GameScreen>();
            xmlGameScreenManager.Type = currentScreen.Type;
            currentScreen = xmlGameScreenManager.Load("Loads/MainScreen.xml");
        }

        public void LoadContent(ContentManager Content)
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            currentScreen.LoadContent(Content);
        }

        public void UnloadContent()
        {
            currentScreen.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
        }
    }
}