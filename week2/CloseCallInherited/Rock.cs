using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloseCallInherited
{
    class Rock : GameObject
    {
        private float _gravity;
        private float _speed;

        public Rock(Vector2 position)
        {
            Position = position;
            Texture = Game1.instance.Content.Load<Texture2D>("Rock");
            Origin = new Vector2(Texture.Width / 2, Texture.Height / 2);
        }

        public override void Update()
        {
            if (Position.Y < 415)
            {
                Position = new Vector2(Position.X + _speed, Position.Y + _gravity);
                // Als er een botsing is geweest met de rots -> roteren
                // ALs de snelheid voor de botsing te klein is mag de rots niet roteren
                if ( _speed > 1)
                    Rotation += 0.1f;
            }
        }

        public void Crash(float vehicleSpeed)
        {
            _speed = vehicleSpeed;
        }

        public void Fall()
        {
            _gravity = 9.78f;
        }
    }
}
