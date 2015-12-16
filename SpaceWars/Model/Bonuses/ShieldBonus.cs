
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceWars.GameObjects;
using SpaceWars.Interfaces;

namespace SpaceWars.Model.Bonuses
{
    public class ShieldBonus: Bonus
    {
        public override void OnGetBonus(IGameObject obj)
        {
            if (obj.GetType() == typeof(Player))
            {
                Player player = (Player)obj;
                player.Shield += 100;
            }
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            
        }

        public override void LoadContent(ResourceManager resourceManager)
        {
            throw new System.NotImplementedException();
        }

        public override void Think(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }
    }
}
