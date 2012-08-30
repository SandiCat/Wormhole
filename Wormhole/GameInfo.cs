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
    //stores the basic info from game classes so that other classes can use it regardless of the game class in question

    public static class GameInfo
    {
        public static SpriteBatch RefSpriteBatch;
        public static GraphicsDevice RefDevice;
        public static GraphicsDeviceManager RefDeviceManager;
        public static ContentManager RefContent;
    }
}