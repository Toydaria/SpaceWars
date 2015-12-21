namespace SpaceWars.GameObjects
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Stringer
    {
        private SpriteFont spriteFont;
        private Vector2 Position { get; set; }
        public string Text { get; set; }

        public Stringer(Vector2 position)
        {
            this.Position = position;
        }

        public void LoadContent(ResourceManager resourceManager)
        {
            spriteFont = resourceManager.GetSpriteFont();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(spriteFont, Text, Position, Color.White);
        }
    }
}
