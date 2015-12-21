﻿namespace SpaceWars.Model
{
    using System;
    using Microsoft.Xna.Framework;
    using SpaceWars.GameObjects;
    using SpaceWars.Interfaces;
    using SpaceWars.Model.Enemies.EnemyBullets;

    public class LittleEnemy: Enemy
    {
    private const int UpCorner = -69; // health bonus size
    private const int RightCorner = 800 - 100; // Screen width - health bonus width
    private const int DownCorner = 950 - 279; // Screen height - health bonus height
    private const int LeftCorner = 0;
    private const int ShootDelayConst = 50;
    private int scoringPoints = 2;
    private int shootDelay = ShootDelayConst;

    public LittleEnemy()
    {
        Random rand = new Random();

        Position = new Vector2(rand.Next(LeftCorner, RightCorner), UpCorner);
        this.Speed = new Vector2(0, 2);

        this.BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, 100, 69);


    }

    public override void OnGetEnemy(IGameObject obj)
    {
        if (obj.GetType() == typeof(Player))
        {
            Player player = (Player)obj;

            player.TakeDMG(+50);

            Owner.RemoveObject(this);
        }
    }

    public override void Shoot()
    {
        if (shootDelay > 0)
        {
            shootDelay--;
        }
        else
        {
            int bulletX = (int)this.Position.X + 22; //22 because half of the texture width - bullet width
            Owner.AddObject(new LittleEnemyBullet(new Vector2(bulletX, this.Position.Y)));

            shootDelay = ShootDelayConst;
        }
    }

    public override void LoadContent(ResourceManager resourceManager)
    {
        Texture = resourceManager.GetResource("littleEnemy");
    }

    public override void Think(GameTime gameTime)
    {
        Shoot();
    }
}
}
