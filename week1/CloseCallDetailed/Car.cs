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

		private SoundEffect	_crashsound;
		private SoundEffect	_brakesound;

        public Vector2      Position    { get; set; }
        public Color        Color       { get; set; }
        public float        Speed       { get; set; }
		public float        Acceleration{ get; set; }
        public float        Scale       { get; set; }

		// state 
		public bool         Crashed     { get; set; }
		private bool 		Braking = false;
		private bool 		Driving = false;


        public Rectangle Bounds
        {
            get
            {
                return new Rectangle(
                        (int)Position.X,
                        (int)Position.Y,
                        (int)(_texture.Width * Scale),
                        (int)((_texture.Height + _wheel1.Texture.Height / 2) * Scale));
            }
        }
        public Car(Vector2 position, float scale, Color color)
        {
            _texture        = Game1.instance.Content.Load<Texture2D>("Car_body");

  
            Scale           = scale;
            Position        = position;
            Color           = color;

            _wheel1         = new Wheel(this, new Vector2(67, 62), Color.Yellow);
            _wheel2         = new Wheel(this, new Vector2(212, 62), Color.Yellow);

			_crashsound	= Game1.instance.Content.Load<SoundEffect>("crash");
			_brakesound	= Game1.instance.Content.Load<SoundEffect>("brake");
        }

        public void Update()
        {
			// de snelheid aanpassen met de acceleration
			Speed += Acceleration;
			if(Speed < 0f) {
				Speed = 0f;
				Acceleration = 0f;
			}

			Position = new Vector2(Position.X + Speed, Position.Y);

			_wheel1.Update();
			_wheel2.Update();
        }

        public void Draw()
        {
            Game1.spriteBatch.Draw(_texture, Position, null, Color, 0, new Vector2(0, 0), Scale, SpriteEffects.None, 0);

            _wheel1.Draw();
            _wheel2.Draw();
        }


		public void Brake()
		{
			if(!Braking) {
				Braking = true;
				Acceleration = -0.08f;
				_brakesound.Play();
			}



		}

		public void Crash(){
			if(!Crashed) {
				Crashed = true;
				_crashsound.Play();
				Acceleration = 0;
				Speed = 0;
			}
		}

		public void Start()
		{
			if(!Driving) {
				Driving = true;
				Acceleration = 0.1f;
			}
		}
        
    }
}
