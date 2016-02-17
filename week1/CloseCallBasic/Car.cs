using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloseCall
{
    class Car
    {
        private Texture2D   _texture;
        private Wheel       _wheel1;
        private Wheel       _wheel2;

        public Vector2      Position    { get; set; }
        public Vector2      Speed       { get; set; }
		public Vector2      BrakeValue  { get; set; }

		public bool         Crashed     { get; set; }
		public bool         Stopped     { get; set; }

        public Rectangle Bounds
        {
            get
            {
                return new Rectangle((int)Position.X,(int)Position.Y,(int)(_texture.Width),(int)(_texture.Height));
            }
        }

		public Car(Vector2 pos)
        {
            _texture        = Game1.instance.Content.Load<Texture2D>("small_car");
			Position 		= pos;
			Speed 			= new Vector2(3f, 0f);
			BrakeValue 		= new Vector2(0f, 0f);

            _wheel1         = new Wheel(this, new Vector2(22, 22));
            _wheel2         = new Wheel(this, new Vector2(72, 22));

			Crashed = false;
			Stopped = false;
        }

        public void Update()
        {
			// afremmen
			Speed -= BrakeValue;

			// check of we stil staan
			if(Speed.X < 0) {
				Speed = Vector2.Zero;
				Stopped = true;
			}

			// bewegen
			Position += Speed;

			_wheel1.Update();
			_wheel2.Update();
        }

        public void Draw()
        {
			Game1.spriteBatch.Draw(_texture, Position, Color.White);

            _wheel1.Draw();
            _wheel2.Draw();
        }


		public void Brake()
		{
			BrakeValue = new Vector2(0.05f, 0f);
		}

		public void Crash(){
			if(!Crashed) {
				Crashed = true;
				Speed = Vector2.Zero;
			}
		}
        
    }
}
