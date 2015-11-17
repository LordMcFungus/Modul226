using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasciTest
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
