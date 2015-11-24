using System.Collections.Generic;

namespace BasciTest._2_5_6_10
{
	class Drivers
	{
		public Queue<string> drivers;

		public Drivers()
		{
			drivers = new Queue<string>();
			drivers.Enqueue("Hans");
			drivers.Enqueue("Petur");
			drivers.Enqueue("Fritzl");
		}
	}
}
