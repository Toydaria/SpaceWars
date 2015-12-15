using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceWars.Interfaces
{
    interface IAsteroid
    {
        Vector2 Origin { get; }
        string Asset { get; }
        int Damage { get; set; }
    }
}
