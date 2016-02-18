using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloseCall
{
    class Counter
    {
        private int         _counts;
        private int         _counter;
        private string      _text;
        private float       _scale;
        private bool        _visible;
        private SpriteFont  _spVerdana;

        public bool CountDownFinished  { get; set; }

        public Counter()
        {
            _counter        = 3;
            _scale          = 5;
            _text           = "3";

            _visible        = true;
            CountDownFinished  = false;
            _spVerdana      = Game1.instance.Content.Load<SpriteFont>("Verdana");
        }
        
        public void Update()
        {
            if (_visible)
            {
                _counts++;
                if (_counts > 60)
                {
                    _counter--;
                    _text = _counter.ToString();
                    _counts = 0;
                }
                if (_counter == 0)
                {
                    CountDownFinished = true;
                    _text = "GO!";
                }
                else if (_counter == -1)
                {
                    _visible = false;
                } 
            }

        }

        public void Draw()
        {
            if (_visible)
            {
                Game1.spriteBatch.DrawString(
                         _spVerdana,
                         _text,
                         new Vector2(Game1.instance.GraphicsDevice.Viewport.Width / 2, Game1.instance.GraphicsDevice.Viewport.Height / 2),
                         Color.White,
                         0,
                         new Vector2(0, 0),
                         _scale,
                         SpriteEffects.None,
                         0);  
            }
        }
    }
}
