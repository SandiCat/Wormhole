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
    public static class MouseManager
    {
        static private MouseState _previousMouseState;
        static public MouseState CurrentMouseState { get; private set; }

        static private Texture2D _texture;
        static private Vector2 _position;

        static public void Initialize()
        {
            Events.Update += new Events.NoArgsDelegate(Update);
            Events.UpdateEnded += new Events.NoArgsDelegate(UpdateEnded);
            
            _previousMouseState = new MouseState();
            CurrentMouseState = new MouseState();

            _texture = new Texture2D(GameInfo.RefDevice, 1, 1);
            _texture.SetData(new Color[] { Color.Black });
        }

        static private void Update()
        {
            //Get mouse info:
            CurrentMouseState = Mouse.GetState();

            //Adjuts position:
            _position = new Vector2(CurrentMouseState.X, CurrentMouseState.Y);
        }
        static private void UpdateEnded()
        {
            _previousMouseState = Mouse.GetState();
        }

        static public bool IsClicked(this GameObject obj)
        {
            //The way I'll check mouse clicks is I'll create a small sprite and check collision:

            //Make a sprite where the mouse is:
            Sprite point = new Sprite(_texture, _position);
            point.Scale = obj.Sprite.Scale;
            point.Rotation = obj.Sprite.Rotation;
            point.Detach(); //So its not drawn

            if (obj.Sprite.GetRectangle().Intersects(point.GetRectangle()))
            {
                if (CollisionChecks.IsCollidingUnoptimized(obj.Sprite, point))
                {
                    if (CurrentMouseState.LeftButton == ButtonState.Pressed
                        && _previousMouseState.LeftButton == ButtonState.Released)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        static public bool IsRightClicked(this GameObject obj)
        {
            //The way I'll check mouse clicks is I'll create a small sprite and check collision:

            //Make a sprite where the mouse is:
            Sprite point = new Sprite(_texture, _position);
            point.Scale = obj.Sprite.Scale;
            point.Rotation = obj.Sprite.Rotation;
            point.Detach(); //So its not drawn

            if (obj.Sprite.GetRectangle().Intersects(point.GetRectangle()))
            {
                if (CollisionChecks.IsCollidingUnoptimized(obj.Sprite, point))
                {
                    if (CurrentMouseState.RightButton == ButtonState.Pressed
                        && _previousMouseState.RightButton == ButtonState.Released)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        static public bool IsMouseOver(this GameObject obj)
        {
            //The way I'll check mouse clicks is I'll create a small sprite and check collision:

            //Make a sprite where the mouse is:
            Sprite point = new Sprite(_texture, _position);
            point.Scale = obj.Sprite.Scale;
            point.Rotation = obj.Sprite.Rotation;
            point.Detach(); //So its not drawn

            if (obj.Sprite.GetRectangle().Intersects(point.GetRectangle()))
            {
                if (CollisionChecks.IsCollidingUnoptimized(obj.Sprite, point))
                {
                    if (CurrentMouseState.LeftButton == ButtonState.Released
                        && _previousMouseState.RightButton == ButtonState.Released)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}