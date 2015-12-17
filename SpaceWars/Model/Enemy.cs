﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceWars.Interfaces;

namespace SpaceWars.Model
{
    public abstract class Enemy: GameObject, IEnemy
    {
        public abstract void OnGetEnemy(IGameObject obj);
        
        public override void Intersect(IGameObject obj)
        {
            OnGetEnemy(obj);
        }
    }
}
