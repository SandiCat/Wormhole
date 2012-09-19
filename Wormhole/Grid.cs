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


namespace Wormhole
{
    public class Grid : GameObject
    {
        public Grid(Vector2 position, int side, int squareSide)
            : base(position)
        {
            _side = side;
            _squareSide = squareSide;
            Sprite.Position = position;

            Objects = new GameObject[_side, _side];
            _positions = new Vector2[_side, _side];

            // Calculate square positions:
            float yPosition = Sprite.Position.Y;

            for (int i = 0; i < _side; i++)
            {
                for (int j = 0; j < _side; j++)
                {
                    _positions[i, j] = new Vector2(_squareSide * j + Sprite.Position.X, yPosition);
                }

                yPosition += _squareSide;
            }
        }


        public GameObject[,] Objects { get; private set; }
        Vector2[,] _positions;

        readonly int _side;
        readonly int _squareSide;

        protected override void Update()
        {
            for (int i = 0; i < _side; i++)
            {
                for (int j = 0; j < _side; j++)
                {
                    GameObject obj = Objects[i, j];

                    if (obj != null) obj.Sprite.Position = _positions[i, j] + obj.Sprite.Origin;
                }
            }
        }

        public Vector2 GetXY(GameObject obj)
        {
            int hashCode = obj.GetHashCode();

            for (int i = 0; i < _side; i++)
            {
                for (int j = 0; j < _side; j++)
                {
                    if (Objects[i, j] != null && Objects[i, j].GetHashCode() == hashCode)
                        return new Vector2(i, j);
                }
            }

            throw new Exception("Object isn't in the grid");
        }
        public void SetPosition(GameObject obj, Vector2 newPosition) //Changes the position of the object to the position in argument
        {
            if (newPosition.X >= _side || newPosition.Y >= _side
                || newPosition.X < 0 || newPosition.Y < 0)
            {
                throw new Exception("Position is outside of the grid");
            }

            Vector2 oldPosition = GetXY(obj);

            Objects[(int)oldPosition.X, (int)oldPosition.Y] = null;

            if (Objects[(int)newPosition.X, (int)newPosition.Y] == null)
            {
                Objects[(int)newPosition.X, (int)newPosition.Y] = obj;
            }
            else
            {
                throw new Exception("Space occupied");
            }
        }
        public void RelativeSetPosition(GameObject obj, Vector2 modifier) //Changes the position of the object by adding and/or subtracting from its coordinates
        {
            Vector2 modifiedPosition = GetXY(obj) + modifier;

            SetPosition(obj, modifiedPosition);
        }

        public Vector2 GetPositionFromXY(int x, int y)
        {
            return new Vector2(x * _squareSide + Sprite.Position.X, y * _squareSide + Sprite.Position.Y);
        }

        public void CreateFromString(Dictionary<char, Type> discription, params string[] rows)
        {
            for (int i = 0; i < rows.GetLength(0); i++)
            {
                for (int j = 0; j < rows[i].Count(); j++)
                {
                    char character = rows[i][j];

                    if (discription[character] != null)
                    {
                        GameObject obj = ObjectHolder.NewOfType(discription[character], new Vector2(0, 0));
                        obj.Sprite.Position += obj.Sprite.Origin; //This makes positon the top left corner, not the origin
                        Objects[i, j] = ObjectHolder.Create(obj);
                    }
                }
            }
        }
    }
}
