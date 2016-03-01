using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloseCallInherited
{
    class Car : Vehicle
    {
        public Car(Vector2 position, float scale, Color color)
            : base(position, scale, color)
        {
            Texture             = Game1.instance.Content.Load<Texture2D>("Car_body");

            brakeSpeed          = -0.35f;
            accelerationAmount  = 0.15f;

            wheels.Add(new Wheel(this, new Vector2(67, 62), Color.Yellow, Scale));
            wheels.Add(new Wheel(this, new Vector2(212, 62), Color.Yellow, Scale));
        }

        
    }
}
