using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloseCall
{
    class Wheel
    {
        private float       _rotation = 0;
        private Car         _car;

        public Texture2D    Texture     { get; set; }
        public Vector2      Position    { get; set; }
        public Vector2      Offset      { get; set; }

		// de origin is het middelpunt van de rotation
        public Vector2 Origin
        {
            get { return new Vector2(Texture.Width / 2, Texture.Height / 2); }
        }

        public Wheel(Car car, Vector2 offset)
        {
            Texture  = Game1.instance.Content.Load<Texture2D>("small_wheel");
            _car     = car;
            Offset   = offset;
        }
        
        public void Update()
        {
            Position = _car.Position + Offset;
			_rotation += 0.07f;
        }

        public void Draw()
        {
			Game1.spriteBatch.Draw(Texture, Position, null, Color.White, _rotation, Origin, 1, SpriteEffects.None, 0);
        }
    }
}
