using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasciTest
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
