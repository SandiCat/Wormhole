using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Wormhole
{
    public static class ObjectHolder
    {
        public static List<GameObject> Objects { public get; private set; }

        public static void Initialize() //since this is a static object
        {
            Objects = new List<GameObject>();
        }

        public static void Create(GameObject obj)
        {
            Objects.Add(obj);
        }
        public static void Delete(GameObject obj)
        {
            Objects.Remove(obj);
            obj.Detach();
        }

        public static GameObject NewOfType(Type type, Vector2 position)
        {
            GameObject obj = (GameObject)Activator.CreateInstance(type);
            obj.Sprite.Position = position;
            return obj;
        }
    }
}
