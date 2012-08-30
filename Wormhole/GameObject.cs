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
            Events.Update += new Events.NoArgsDelegate(Update);
        }

        public abstract void Update();

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
    }
}
