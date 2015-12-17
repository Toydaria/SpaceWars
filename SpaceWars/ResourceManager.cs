using System.Collections.Generic;

namespace SpaceWars
{
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class ResourceManager
    {

        private Dictionary<string, Texture2D> resources = new Dictionary<string, Texture2D>();


        public void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            resources["ship"] = content.Load<Texture2D>("ship");
            resources["laser"] = content.Load<Texture2D>("laser");
            resources["asteroid"] = content.Load<Texture2D>("asteroid");
            resources["HealthBonus"] = content.Load<Texture2D>("HealthBonus");
            resources["ShieldBonus"] = content.Load<Texture2D>("ShieldBonus");
        }

        public Texture2D GetResource(string resourceName)
        {
            return resources[resourceName];
        }
    }
}
