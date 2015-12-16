using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceWars.GameObjects;
using SpaceWars.Interfaces;

namespace SpaceWars
{
    using SpaceWars.Model;
    using SpaceWars.GameObjects.AsteroidsPack;
   

    public class ObjectManager
    {
        
        List<IGameObject> objects = new List<IGameObject>();
        private int elapsedAsteroidTime = 0;
        private const int AsteroidFieldPeriod = 80;

        public ResourceManager ResourceMgr { get; set; }

        public ObjectManager()
        {
            ResourceMgr = new ResourceManager();
        }

        public void AddObject(IGameObject obj)
        {
            obj.Owner = this;
            obj.LoadContent(ResourceMgr);
            objects.Add(obj);
        }

        public bool RemoveObject(IGameObject obj)
        {
           obj.NeedToRemove = true;
           return true; 
        }

        bool RemoveObjectPrivate(IGameObject obj)
        {
            return objects.Remove(obj);
        }

        public void Update(GameTime gametime)
        {
            Think(gametime);
            Move();
            CheckCollision();
            RemoveGarbage();

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var obj in objects)
            {
                obj.Draw(spriteBatch);
            }
        }

        public void CheckCollision()
        {
            foreach (var firstObject in objects)
            {
                foreach (var secondObject in objects)
                {
                    if (!Object.ReferenceEquals(firstObject, secondObject))
                    {
                        if (firstObject.BoundingBox.Intersects(secondObject.BoundingBox))
                        {
                            firstObject.Intersect(secondObject);
                        }
                    }
                }
            }
        }

        public void Move()
        {
            foreach (var obj in objects)
            {
                obj.Move();
            }
        }

        public void Think(GameTime gametime)
        {
            CreateAsteroidField(gametime);
            for (int i = 0; i < objects.Count; ++i)
            {
                objects[i].Think(gametime);
            }  
        }

        public void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            ResourceMgr.LoadContent(content);
        }

        void CreateAsteroidField(GameTime gametime)
        {
            elapsedAsteroidTime += gametime.ElapsedGameTime.Milliseconds;

            if(elapsedAsteroidTime > AsteroidFieldPeriod)
            {
                elapsedAsteroidTime = 0;
                var asteroid = GetAsteroid();
                AddObject(asteroid);
            }
        }

        
        void RemoveGarbage()
        {
            for (int i = objects.Count - 1; i >= 0; i--)
            {
                if (objects[i].NeedToRemove)
                    RemoveObjectPrivate(objects[i]);
            }
        }

        private Asteroid GetAsteroid()
        {
            Random randomAsteroid = new Random();
            int index = randomAsteroid.Next(0, 3);
            switch (index)
            {
                case 0:
                    return new ChunkyAsteroid();
                case 1:
                    return new RockyAsteroid();
                case 2:
                    return new RedFartAsteroid();
            }
            return null;
        }
    }
}
