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
    public static class Grid
    {
        static public void Initialize(int squareSide)
        {
            SquareSide = squareSide;
        }

        static public int SquareSide;

        static public Vector2 GetXYPosition(Vector2 XY)
        {
            return new Vector2(XY.X * SquareSide, XY.Y * SquareSide);
        }
        static public Vector2 GetXYFromPosition(Vector2 position)
        {
            float x = (float)Math.Floor(position.X / SquareSide);
            float y = (float)Math.Floor(position.Y / SquareSide);

            return new Vector2(x, y);
        }
    }
}
