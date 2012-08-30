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
    public static class TileObjectCreator
    {
        public static void Create(int elementWidth, int elementHeight, Vector2 position, 
            Dictionary<char, Type> discription, params string[] rows)
        {
            float x = position.X;
            float y = position.Y;


            foreach (var row in rows)
            {
                foreach (var character in row)
                {
                    if (discription[character] != null)
                    {
                        ObjectHolder.Create(ObjectHolder.NewOfType(discription[character], new Vector2(x, y)));
                    }
                    x += elementWidth;
                }
                x = position.X;
                y += elementHeight;
            }
        }

        public static void CreateWithinGrid(Dictionary<char, Type> discription, params string[] rows)
        {
            Create(Grid.SquareSide, Grid.SquareSide, new Vector2(0, 0), discription, rows);
        }
    }
}
