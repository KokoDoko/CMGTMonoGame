using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloseCallInherited
{
    class Wheel : GameObject
    {
        private float       _rotation;
        private Vehicle     _vehicle;

        public Vector2      Offset      { get; set; }
        
        /// <summary>
        /// Center of the wheel
        /// </summary>
        public override Vector2 Origin
        {
            get { return new Vector2(Texture.Width / 2, Texture.Height / 2); }
        }

        public override float   Rotation
        {
            get
            {
                return _rotation % (MathHelper.Pi * 2);
            }
            set
            {
                _rotation = value;
            }
        }

        public Wheel(Vehicle vehicle, Vector2 offset, Color color, float scale)
        {
            Texture  = Game1.instance.Content.Load<Texture2D>("Car_wheel");
            _vehicle = vehicle;
            Offset   = offset * _vehicle.Scale;
            Position = new Vector2(_vehicle.Position.X + Offset.X, _vehicle.Position.Y + Offset.Y);
            Color    = color;
            Scale    = scale;
        }
        
        public override void Update()
        {
            Position = new Vector2(_vehicle.Position.X + Offset.X, _vehicle.Position.Y + Offset.Y);
            _rotation += _vehicle.Speed * 0.07f;
        }
    }
}
