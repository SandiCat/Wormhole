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
    public class Alarm
    {
        int? counter;

        public Alarm(int time)
        {
            counter = time;
        }
        public Alarm()
        {
            counter = null;
        }

        // this method updates the alarm AND tells you if its done
        // as long as an object is calling this method in its alarm method, this alarm is updated properly.
        // when an alarm is done with its counting, it will return true, but after that it will return false untill its restarted
        public bool IsDone()
        {
            if (counter != 0 && counter != null) counter--;

            if (counter == 0)
            {
                counter = null;
                return true;
            }
            else
                return false;
        } 
            
        public void Restart(int time)
        {
            counter = time;
        }
    }
}
