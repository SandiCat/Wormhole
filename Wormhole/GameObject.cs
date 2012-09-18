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
    public abstract class GameObject
    {
        public Sprite Sprite;

        public GameObject()
        {
            try
            {
                Sprite = new Sprite(TextureHolder.DefaultTextures[this.GetType()], new Vector2(0, 0));
            }
            catch
            {
                Sprite = new Sprite(TextureHolder.EmptyTexture, new Vector2(0, 0));
            }
        }
        public GameObject(Vector2 position)
        {
            try
            {
                Sprite = new Sprite(TextureHolder.DefaultTextures[this.GetType()], position);
            }
            catch
            {
                Sprite = new Sprite(TextureHolder.EmptyTexture, position);
            }
        }

        protected abstract void Update();

        public void Attach()
        {
            Events.Update += new Events.NoArgsDelegate(Update);
            Sprite.Attach();
        }
        public void Detach()
        {
            Events.Update -= new Events.NoArgsDelegate(Update);
            Sprite.Detach();
        }

        public bool IsDestroyed()
        {
            if (!ObjectHolder.Objects.Contains(this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Some basic common actions an object can do:
        public void StepTowards(Vector2 point, float distance)
        {
            point.Normalize();
            Sprite.Position += point * distance;
        }
        public void StepAngle(float angle, float distance)
        {
            Vector2 up = new Vector2(0, -1);
            Matrix rotationMat = Matrix.CreateRotationZ(angle);
            Vector2 direction = Vector2.Transform(up, rotationMat);

            Sprite.Position += direction * distance;
        }
        public void ChangeObject(Type type)
        {
            ObjectHolder.Delete(this);

            GameObject newObject = ObjectHolder.NewOfType(type, Sprite.Position);
            ObjectHolder.Create(newObject);
            newObject.Sprite.Origin = Sprite.Origin;
        }
    }
}
