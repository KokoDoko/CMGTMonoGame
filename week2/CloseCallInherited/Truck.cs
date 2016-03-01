using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloseCallInherited
{
    class Truck : Vehicle
    {
        public Truck(Vector2 position, float scale, Color color)
            : base(position, scale, color)
        {
            Texture             = Game1.instance.Content.Load<Texture2D>("truck");

            brakeSpeed          = -0.03f;
            accelerationAmount  = 0.015f;

            wheels.Add(new Wheel(this, new Vector2(115, 400), Color.Gray  , Scale * 4f));
            wheels.Add(new Wheel(this, new Vector2(250, 400), Color.Yellow, Scale * 4f));
            wheels.Add(new Wheel(this, new Vector2(670, 400), Color.Gray  , Scale * 4f));
        }
    }
}
