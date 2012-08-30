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
    public class Sprite //keeps an image and draws it
    {
        public Texture2D Image;

        public float Scale = 1.0f;
        public float Rotation = 0.0f;
        public Color Color = Color.White;
        public Vector2 Position = new Vector2();
        public Vector2 Origin = new Vector2();

        public Sprite(Texture2D image, Vector2 position, Vector2 origin, float roatation, float scale)
        {
            Image = image;

            Scale = scale;
            Rotation = roatation;
            Position = position;
            Origin = origin;

            Events.Draw += new Events.NoArgsDelegate(Draw);
        }
        public Sprite(Texture2D image, Vector2 position)
        {
            Image = image;

            Position = position;
        }

        public void Draw()
        {
            GameInfo.RefSpriteBatch.Draw(Image, Position, null, Color, Rotation, Origin, Scale, SpriteEffects.None, 0.0f);
        }

        public Matrix GetMatrix()
        {
            Matrix matrix =
                Matrix.CreateTranslation(-Origin.X, -Origin.Y, 0)
                * Matrix.CreateRotationZ(Rotation)
                * Matrix.CreateScale(Scale)
                * Matrix.CreateTranslation(Position.X, Position.Y, 0);

            return matrix;
        }
        public Rectangle GetRectangle()
        {
            if (Scale == 1.0f && Rotation == 0.0f && Origin == Position)
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Image.Width, Image.Height);
            }
            else
            {
                Rectangle rectangle = new Rectangle(0, 0, Image.Width, Image.Height);

                Matrix transform = GetMatrix();

                // Get all four corners in local space
                Vector2 leftTop = new Vector2(rectangle.Left, rectangle.Top);
                Vector2 rightTop = new Vector2(rectangle.Right, rectangle.Top);
                Vector2 leftBottom = new Vector2(rectangle.Left, rectangle.Bottom);
                Vector2 rightBottom = new Vector2(rectangle.Right, rectangle.Bottom);

                // Transform all four corners into work space
                leftTop = Vector2.Transform(leftTop, transform);
                rightTop = Vector2.Transform(rightTop, transform);
                leftBottom = Vector2.Transform(leftBottom, transform);
                rightBottom = Vector2.Transform(rightBottom, transform);

                // Find the minimum and maximum extents of the rectangle in world space
                Vector2 min = Vector2.Min(Vector2.Min(leftTop, rightTop),
                                          Vector2.Min(leftBottom, rightBottom));
                Vector2 max = Vector2.Max(Vector2.Max(leftTop, rightTop),
                                          Vector2.Max(leftBottom, rightBottom));

                // Return that as a rectangle
                return new Rectangle((int)min.X, (int)min.Y,
                                     (int)(max.X - min.X), (int)(max.Y - min.Y));
            }
        }
        public Color[] GetColorData()
        {
            Color[] colorData = new Color[Image.Width * Image.Height];
            Image.GetData(colorData);

            return colorData;
        }
        public Vector2 GetTopLeftCorner()
        {
            return Position - Origin;
        }

        public void Detach()
        {
            Events.Draw -= new Events.NoArgsDelegate(Draw);
        }
    }
}
