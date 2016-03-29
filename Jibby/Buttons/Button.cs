using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace JibbyIsMyFriend
{
    abstract class Button : GameObject
    {
        private MouseState _previousMouse;

        protected Jibby Jibby { get; set; }
        protected Texture2D mouseDownButton { get; set; }
        protected Texture2D mouseUpButton { get; set; }

        public Button(Vector2 position, Jibby jibby)
            : base(position)
        {
            Jibby = jibby;
        }

        public override void Update()
        {
            Texture = mouseUpButton;

            MouseState mouse = Mouse.GetState();

            if (mouse.LeftButton == ButtonState.Pressed)
            {
                if (_previousMouse.LeftButton == ButtonState.Released)
                {
                    if (BoundingBox.Contains(mouse.X, mouse.Y))
                    {
                        Texture = mouseDownButton;
                        ButtonAction();
                    } 
                }
            }

            _previousMouse = mouse;
        }

        protected abstract void ButtonAction();
    }
}
