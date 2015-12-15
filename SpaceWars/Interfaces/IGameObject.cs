using Microsoft.Xna.Framework;

namespace SpaceWars.Interfaces
{

    using Microsoft.Xna.Framework.Graphics;

    public interface IGameObject
    {
        Texture2D Texture { get; set; }

        Vector2 Position { get; set; }

        Vector2 Speed { get; set; }

        Rectangle BoundingBox { get; set; }

    }
}
