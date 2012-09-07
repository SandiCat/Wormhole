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
        public static List<GameObject> Objects { get; private set; }

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

        public static bool AreThereObjectsAt(Vector2 point)
        {
            //The way I'll check point collisions is I'll create a small sprite and check collision:

            //Make the texture:
            Texture2D texture = new Texture2D(GameInfo.RefDevice, 1, 1);
            texture.SetData(new Color[] { Color.Black });

            //Make a sprite where the the point is:
            Sprite sprite = new Sprite(texture, point);
            sprite.Detach(); //So its not drawn

            foreach (var obj in ObjectHolder.Objects)
            {
                sprite.Scale = obj.Sprite.Scale;
                sprite.Rotation = obj.Sprite.Rotation;

                if (obj.Sprite.GetRectangle().Intersects(sprite.GetRectangle()))
                {
                    if (CollisionChecks.IsCollidingUnoptimized(obj.Sprite, sprite))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        public static GameObject NewOfType(Type type, Vector2 position)
        {
            GameObject obj = (GameObject)Activator.CreateInstance(type);
            obj.Sprite.Position = position;
            return obj;
        }
    }
}
