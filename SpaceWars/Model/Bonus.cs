using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using SpaceWars.Interfaces;
using SpaceWars.Model.Bonuses;

namespace SpaceWars.Model
{
    public abstract class Bonus: GameObject, IBonus
    {
        public abstract void OnGetBonus(IGameObject obj);

        public override void Intersect(IGameObject obj)
        {
            OnGetBonus(obj);
        }

       
    }

    
}
