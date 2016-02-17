using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloseCall
{
    class World
    {
        private Car         _car;
        private Rock        _rock;
        private Texture2D   _background;

        private string      _score = "";
        private SpriteFont  _spVerdana;

        public World()
        {
			_car 		= new Car(new Vector2(0, 164));
            _rock       = new Rock(new Vector2(610, 160));
            _background = Game1.instance.Content.Load<Texture2D>("cliff");
            _spVerdana  = Game1.instance.Content.Load<SpriteFont>("Verdana");

        }

        public void Update()
		{
			_car.Update();
			_rock.Update();

			checkCollision();
			checkScore();
			checkKeyboard();
		}
	

		public void checkKeyboard(){
			KeyboardState keyboardState = Keyboard.GetState();

			if (keyboardState.IsKeyDown(Keys.Space))
			{
				_car.Brake();
			}

			if (keyboardState.IsKeyDown(Keys.R))
			{
				Game1.instance.Reset();
			}
		}


		public void checkCollision(){
			if (_car.Bounds.Intersects(_rock.Bounds))
			{
				_rock.Crash();
				_car.Crash();
			}
		}


		public void checkScore(){
            if (_car.Crashed)
				_score = "You Crashed        druk op R";
			else if (_car.Stopped)
				_score = "You scored: " + (_rock.Position.X - _car.Bounds.Right).ToString() + "        druk op R";
            else
                _score = "Distance: " + (_rock.Position.X - _car.Bounds.Right).ToString();
        }


        public void Draw()
        {
            Game1.spriteBatch.Draw(_background, Game1.instance.GraphicsDevice.Viewport.Bounds, Color.White);
            _car.Draw();
            _rock.Draw();
            Game1.spriteBatch.DrawString(_spVerdana, _score, new Vector2(200, 70), Color.White);
        }
    }
}
