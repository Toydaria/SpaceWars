using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceWars.GameObjects;
using SpaceWars.Interfaces;

namespace SpaceWars.Model.Bonuses
{
    abstract class HealthBonus: Bonus
    {
        private bool consumedBonus;
        private Texture2D texture;


        public HealthBonus()
        {
            this.Position = new Vector2(20, 890);
            this.BoundingBox = new Rectangle(20,890,50,50);

        }


        

       // public override void Draw(SpriteBatch spriteBatch)
       // {
          //  spriteBatch.Draw(texture, Position, Color.White);
        //   base.Draw(spriteBatch);
        //}

       // public void LoadContent(ContentManager Content)
       // {
         //   texture = Content.Load<Texture2D>("healthbonus");
        //}

        public override void OnGetBonus(IGameObject obj)
        {
           if (obj.GetType() == typeof(Player))
           {
               Player player = (Player) obj;
               player.Speed = new Vector2(10,0);

           }
        }


        public override void LoadContent(ResourceManager resourceManager)
        {
            throw new NotImplementedException();
        }

        public abstract override void Think(GameTime gameTime);
        
    }
}
