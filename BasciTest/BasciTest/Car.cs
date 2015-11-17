using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasciTest
{
	class Car : CarBase
	{
		public Car()
		{
			
		}

		public Car(string colour, string type, string producer)
		{
			this.Colour = colour;
			this.Type = type;
			this.Producer = producer;
		}
	}
}
