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
    public static class SoundHolder
    {
        public static Dictionary<string, SoundEffect> Sounds;

        public static void Initialize() //since this is a static object
        {
            Sounds = new Dictionary<string, SoundEffect>();
        }
        public static SoundEffect AddSound(string filename)
        {
            SoundEffect sound = GameInfo.RefContent.Load<SoundEffect>(filename);
            Sounds.Add(filename, sound);

            return Sounds[filename];
        }
    }
}