using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceExample
{
    class World
    {
		private List<GameObject> vehicles = new List<GameObject>();

        public World()
        {
			vehicles.Add(new Car());
			vehicles.Add(new Truck());

		}

        public void Update()
		{
			foreach(GameObject go in vehicles) {
				go.Update();
				go.Draw();
			}
		}

        public void Draw()
        {
			foreach(GameObject go in vehicles) {
				go.Update();
				go.Draw();
			}
        }
    }
}
