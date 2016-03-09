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
	public class Truck : GameObject, IClickable, IExplodable
	{
		public bool IsClicked { get ; set; }
		public int Health { get ; set; }

		public Truck(){
			Health = 0;
		}

		public void OnClick()
		{
		}
			
		public bool CheckExplode()
		{
			return (Health <= 0);
			
		}

	}
}