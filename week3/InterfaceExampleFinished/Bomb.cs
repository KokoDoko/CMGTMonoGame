using System;

namespace InterfaceExample
{
	public class Bomb : GameObject, ICollectable
	{
		public Bomb()
		{
		}


		public string OnCollect()
		{
			return "a bomb!!!!";
		}

	}
}

