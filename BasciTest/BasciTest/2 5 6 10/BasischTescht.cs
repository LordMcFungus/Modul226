using System;
using System.Linq;

namespace BasciTest._2_5_6_10
{
	class BasischTescht
	{
		private ICarBase Car;
		private Drivers driver = new Drivers();
		private Cars cars = new Cars();
		public BasischTescht()
		{
			DelegateCar();
		}

		private void DelegateCar()
		{
			Car = cars.CarSet.First();
			Car.driver = driver.drivers.Dequeue();
			Car.Drive();
			var a = new Random().Next(1, 100);
		}
	}
}
