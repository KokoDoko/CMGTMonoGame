using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloseCallInherited
{
    class Vehicle : GameObject
    {
        private float _acceleration;

        protected bool _driving;
        protected bool _braking;
                
        protected float accelerationAmount;
        protected float brakeSpeed;
        protected List<Wheel> wheels;

        public float        Speed       { get; set; }
        public bool         Crashed     { get; set; }

        public override Rectangle Bounds
        {
            get
            {
                return new Rectangle(
                        (int)Position.X,
                        (int)Position.Y,
                        (int)(Texture.Width * Scale),
                        (int)((Texture.Height + wheels[0].Texture.Height / 2) * Scale));
            }
        }
        public Vehicle(Vector2 position, float scale, Color color)
        {
            Scale           = scale;
            Position        = position;
            Color           = color;

            wheels          = new List<Wheel>();
        }
        public override void Update()
        {
            Speed += _acceleration;
            if(_braking && Speed < 0.2f) Speed = 0;

            Position = new Vector2(Position.X + Speed, Position.Y);

            foreach (Wheel wheel in wheels)
            {
                wheel.Update();
            }
        }

        public override void Draw()
        {
            base.Draw();

            foreach (Wheel wheel in wheels)
            {
                wheel.Draw();
            }
        }

        public void Brake()
        {
            if (!_braking)
            {
                _braking = true;
                _acceleration = brakeSpeed;
            }
        }

        public void Crash()
        {
            if (!Crashed)
            {
                Crashed = true;
                _acceleration = 0;
                Speed = 0;
            }
        }

        public void Start()
        {
            if (!_driving)
            {
                _driving = true;
                _acceleration = accelerationAmount;
            }
        }
    
    }
}
