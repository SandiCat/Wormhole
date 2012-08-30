using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Wormhole
{
    public static class Directions
    {
        public static readonly float Up  = MathHelper.ToRadians(0);
        public static readonly float Down = MathHelper.ToRadians(180);
        public static readonly float Left = MathHelper.ToRadians(180 + 90);
        public static readonly float Right = MathHelper.ToRadians(90);

        public static readonly float UpLeft = MathHelper.ToRadians(360 - 45);
        public static readonly float UpRight = MathHelper.ToRadians(45);
        public static readonly float DownLeft = MathHelper.ToRadians(180 + 45);
        public static readonly float DownRight = MathHelper.ToRadians(180 - 45);
    }
}