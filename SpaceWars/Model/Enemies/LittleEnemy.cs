using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceWars.GameObjects;
using SpaceWars.Interfaces;

namespace SpaceWars.Model
{
    public class LittleEnemy: Enemy
    {
    private const int UpCorner = -69; // health bonus size
    private const int RightCorner = 800 - 100; // Screen width - health bonus width
    private const int DownCorner = 950 - 279; // Screen height - health bonus height
    private const int LeftCorner = 0;


    public LittleEnemy()
    {
        Random rand = new Random();

        Position = new Vector2(rand.Next(LeftCorner, RightCorner), UpCorner);
        this.Speed = new Vector2(0, 7);

        this.BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, 100, 69);


    }

    public override void OnGetEnemy(IGameObject obj)
    {
        if (obj.GetType() == typeof(Player))
        {
            Player player = (Player)obj;

            //Molq ako mojesh da napravish metod koito da e GiveHealth ili neshto takova.
            player.TakeDMG(+50);

            Owner.RemoveObject(this);
        }
    }


    public override void LoadContent(ResourceManager resourceManager)
    {
        Texture = resourceManager.GetResource("littleEnemy");
    }

    public override void Think(GameTime gameTime)
    {
        Speed = new Vector2(4 * (float)Math.Cos(gameTime.TotalGameTime.Milliseconds / 300), Speed.Y);
    }
}
}
