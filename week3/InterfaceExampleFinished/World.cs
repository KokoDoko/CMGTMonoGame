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
		private List<GameObject> _gameobjects = new List<GameObject>();

        public World()
        {
			_gameobjects.Add(new Car());
			_gameobjects.Add(new Truck());
			_gameobjects.Add(new AirPlane());
			_gameobjects.Add(new HealthPack());
			_gameobjects.Add(new Bomb());
		}

        public void Update()
		{
			foreach(GameObject go in _gameobjects) {
				go.Update();

				if(go is ICollectable) {

					string str = ((ICollectable)go).OnCollect();
					Console.WriteLine("We have collected: " + str);
				}


				if(go is IExplodable) {

					if(((IExplodable)go).CheckExplode()){
						Console.WriteLine("BOOOM!!");
					}			
				}
			}


		}
	
        public void Draw()
        {
			
        }
    }
}
