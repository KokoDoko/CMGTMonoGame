using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloseCallInherited
{
    class World
    {
        private Vehicle     _vehicle;
        private Counter     _counter;
        private Rock        _rock;
        private Texture2D   _background;

        private string      _score = "";
        private SpriteFont  _spVerdana;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="option">The option indicates which vehicle has been chosen</param>
        public World(int option)
        {
            switch (option)
            {
                case 1:
                    _vehicle = new Car(new Vector2(0, 172), 0.3f, Color.PaleGreen);
                    break;
                case 2:
                    _vehicle  = new Truck(new Vector2(0, 130), 0.13f, Color.Red);
                    break;
            }
            
            
            _counter    = new Counter();
            _rock       = new Rock(new Vector2(626, 178));
            _background = Game1.instance.Content.Load<Texture2D>("cliff");
            _spVerdana  = Game1.instance.Content.Load<SpriteFont>("Verdana");
        }

        public void Update()
        {
            _vehicle.Update();
            _counter.Update();
            _rock.Update();

            //handle counter
            if (_counter.CountDownReady)
            {
                _vehicle.Start();
                // Alleen als het spel start mag het toetsenbord reageren
                HandleKeyboard();
            }

            CheckCollision();
            

            if (_vehicle.Crashed)
                _score = "You Crashed";
            else
                _score = "Distance: " + (_rock.Position.X - _vehicle.Bounds.Right).ToString();
        }

        private void HandleKeyboard()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Space))
            {
                _vehicle.Brake();
            }

            if (keyboardState.IsKeyDown(Keys.R))
            {
                Game1.instance.Reset();
            }
        }

        private void CheckCollision()
        {
            if (_vehicle.Bounds.Intersects(_rock.Bounds))
            {
                _rock.Crash(_vehicle.Speed);
                _vehicle.Crash();
            }

            // When the road ends, the rock will fall down
            if (!_rock.Bounds.Intersects(new Rectangle(0, 0, 630, Game1.instance.GraphicsDevice.Viewport.Height)))
                _rock.Fall();
        }

        public void Draw()
        {
            // Volgorde van tekenen is hier bepalend.
            Game1.spriteBatch.Draw(_background, Game1.instance.GraphicsDevice.Viewport.Bounds, Color.White);
            _vehicle.Draw();
            _counter.Draw();
            _rock.Draw();
            Game1.spriteBatch.DrawString(_spVerdana, _score, new Vector2(185, 70), Color.DarkGreen);
        }
    }
}
