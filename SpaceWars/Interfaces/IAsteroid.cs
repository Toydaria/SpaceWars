using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceWars.Interfaces
{
    public interface IAsteroid: IGiveScore
    {
        int Damage { get; set; }
    }
}
