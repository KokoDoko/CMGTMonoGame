using System;

namespace InterfaceExample
{
	public class Car : GameObject, IUsesFuel, IUpgradable
	{
		public Car()
		{


			Console.WriteLine("Vroom");
		}

		public int Fuel { get; set;}

		public void UseFuel()
		{
		}


		public void OnUpgrade()
		{
		}
	}
}

