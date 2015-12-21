namespace SpaceWars.GameObjects
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using SpaceWars.Model;

    public class Stringer 
    {
        private SpriteFont spriteFont;
        private Vector2 Position { get; set; }
        public string Text { get; set; }
        public Color Color { get; set; }

        public Stringer(Vector2 position)
        {
            this.Position = position;
            this.Color = Color.White;
        }

        public  void LoadContent(ResourceManager resourceManager)
        {
            spriteFont = resourceManager.GetSpriteFont();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(spriteFont, Text, Position, Color);
        }
    }
}
