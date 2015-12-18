using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceWars.Interfaces
{
    public interface IEnemy: IGiveScore
    {
        void OnGetEnemy(IGameObject obj);

        void Shoot();
    }

}
