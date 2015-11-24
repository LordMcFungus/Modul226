using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasciTest
{
	class Cars
	{
		public ISet<ICarBase> CarSet;

		public Cars()
		{
			CarSet = new HashSet<ICarBase>()
			{
				new Car("Red","Truck","Hummer"),
				new Car("Black", "Coupé", "Aston Martin"),
				new Car("Green", "Spyder", "Bentley")
			};
		}
	}
}
