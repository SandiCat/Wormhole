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
    public static class KeyboardManager
    {
        static private List<Keys> previousKeyboardState;
        static private List<Keys> currentKeyboardState;
        static public List<Keys> PressedKeys { get; private set; }
        static public List<Keys> ReleasedKeys { get; private set; }
        static public List<Keys> KeysDown { get; private set; }

        static public void Initialize()
        {
            Events.Update += new Events.NoArgsDelegate(Update);
            Events.UpdateEnded += new Events.NoArgsDelegate(UpdateEnded);

            previousKeyboardState = new List<Keys>();
            currentKeyboardState = new List<Keys>();
            PressedKeys = new List<Keys>();
            ReleasedKeys = new List<Keys>();
            KeysDown = new List<Keys>();
        }

        static private void Update()
        {
            currentKeyboardState = Keyboard.GetState().GetPressedKeys().ToList();

            //Clear lists:
            PressedKeys.Clear();
            ReleasedKeys.Clear();
            KeysDown.Clear();

            //Get keys that are down:
            KeysDown = currentKeyboardState;

            //Get pressed keys:
            foreach (var key in currentKeyboardState)
            {
                if (!previousKeyboardState.Contains(key))
                    PressedKeys.Add(key);
            }

            //Get released keys:
            foreach (var key in previousKeyboardState)
            {
                if (!currentKeyboardState.Contains(key))
                    ReleasedKeys.Add(key);
            }
        }
        static private void UpdateEnded()
        {
            previousKeyboardState = Keyboard.GetState().GetPressedKeys().ToList(); 
        }
    }
}