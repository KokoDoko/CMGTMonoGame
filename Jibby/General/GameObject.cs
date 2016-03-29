using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JibbyIsMyFriend
{
    public class GameObject
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Color Color { get; set; }
        public float Rotation { get; set; } // default value is 0
        public Vector2 Origin { get; set; } // default value is new Vector2(0, 0)
        public float Scale { get; set; }
        public Vector2 Speed { get; set; }  // default value is new Vector2(0, 0)
        public float Alpha { get; set; }

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                    (int)(Position.X - Origin.X),
                    (int)(Position.Y- Origin.Y),
                    (int)(Texture.Width * Scale),
                    (int)(Texture.Height * Scale)
                    );
            }
        }

        public GameObject(Vector2 position)
        {
            Position = position;
            Scale = 1f;
            Alpha = 1f;
            Color = Color.White;
        }

        public virtual void Update()
        {
            Position += Speed;
        }

        public virtual void Draw()
        {
            Game1.spriteBatch.Draw(
                Texture,
                Position,
                null,
                Color.White * Alpha,
                Rotation,
                Origin,
                Scale,
                SpriteEffects.None,
                0
                );
        }
    }
}
