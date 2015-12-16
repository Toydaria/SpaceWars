using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceWars.Interfaces;

namespace SpaceWars.Model
{
<<<<<<< HEAD
    public class LittleEnemy: Enemy
=======
    class LittleEnemy
>>>>>>> 0c4448ba661d6cf429691f3cabc5a0374de6390f
    {
        public override void Intersect(IGameObject obj)
        {
            throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        }

        public override void LoadContent(ResourceManager resourceManager)
        {
            throw new NotImplementedException();
        }

        public override void Think(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
