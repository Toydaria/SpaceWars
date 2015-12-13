namespace SpaceWars.Model
{

    using SpaceWars.Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class GameObject : IGameObject
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public float Speed { get; set; }
        public Rectangle BoundingBox { get; set; }
    }
}
