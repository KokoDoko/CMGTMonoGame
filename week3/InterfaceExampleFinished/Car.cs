using System;

namespace InterfaceExample
{
	public class Car : GameObject, IExplodable
	{
		public int Health { get; set; }

		public Car()
		{
			Health = 10;
			Console.WriteLine("Vroom");
		}

		public override void Update()
		{
			Health -= 2;
		}

		public bool CheckExplode()
		{
			return (Health <= 0);
		}
	}
}

