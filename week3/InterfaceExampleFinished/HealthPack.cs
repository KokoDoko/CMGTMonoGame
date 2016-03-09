using System;

namespace InterfaceExample
{
	public class HealthPack : GameObject, ICollectable
	{
		public HealthPack()
		{
			
		}


		public string OnCollect()
		{
			return "some health :)";
		}

	}
}

