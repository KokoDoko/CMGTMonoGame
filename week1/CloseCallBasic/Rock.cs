using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloseCall
{
    class Rock
    {
        private Texture2D   _texture;

        public Vector2      Position    { get; set; }
        public Vector2      Speed       { get; set; }

        public Rectangle    Bounds
        {
			get
			{
				return new Rectangle((int)Position.X,(int)Position.Y,(int)(_texture.Width),(int)(_texture.Height));
			}
        }

        public Rock(Vector2 position)
        {
            Position = position;
            _texture = Game1.instance.Content.Load<Texture2D>("Rock");
        }

		public void Crash(){
			Speed     = new Vector2(1f, 2f);
		}

        public void Update()
        {
            if (Position.Y < 415)
            {
				Position += Speed;
            }
        }

        public void Draw()
        {
            Game1.spriteBatch.Draw(_texture, Position, Color.White);
        }
    }
}
