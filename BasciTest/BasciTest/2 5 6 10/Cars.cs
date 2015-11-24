using System.Collections.Generic;

namespace BasciTest._2_5_6_10
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
