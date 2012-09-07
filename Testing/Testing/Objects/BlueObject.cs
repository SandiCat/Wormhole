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

using Wormhole;

namespace TestingNamespace
{
    public class BlueObject : GameObject
    {
        public BlueObject() : base()
        {
        }
        public BlueObject(Vector2 position) : base(position)
        {
        }

        Alarm MyAlarm = new Alarm(120);

        protected override void Update()
        {
            if (MyAlarm.IsDone())
            {
                StepAngle(Directions.Right, 10);
                MyAlarm.Restart(30);
            }

            if (this.IsClicked())
            {
                StepAngle(Directions.Right, -15);
            }

            if (KeyboardManager.KeysDown.Contains(Keys.Space))
            {
                Sprite.Position.X = WindowChecks.Width() / 2 - Sprite.Image.Width / 2;
            }
            if (KeyboardManager.PressedKeys.Contains(Keys.D))
            {
                ObjectHolder.Delete(this);
            }

            if (this.IsIntersecting())
            {
                StepAngle(Directions.Right, -100);
            }
        }
    }
}
