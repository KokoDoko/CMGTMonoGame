﻿using Microsoft.Xna.Framework;
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
        public Color        Color       { get; set; }

        public Vector2 Origin
        {
            get { return new Vector2(Texture.Width / 2, Texture.Height / 2); }
        }

        public Wheel(Car car, Vector2 offset, Color color)
        {
            Texture  = Game1.instance.Content.Load<Texture2D>("Car_wheel");
            _car     = car;
            Offset   = offset * _car.Scale;
            Position = new Vector2(_car.Position.X + Offset.X, _car.Position.Y + Offset.Y);
            Color    = color;
        }
        
        public void Update()
        {
            Position = new Vector2(_car.Position.X + Offset.X, _car.Position.Y + Offset.Y);
			_rotation += _car.Speed * 0.07f;
        }

        public void Draw()
        {
			Game1.spriteBatch.Draw(Texture, Position, null, Color, _rotation, Origin, _car.Scale, SpriteEffects.None, 0);
        }
    }
}
