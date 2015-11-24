using System;

namespace BasciTest._2_5_6_10
{
	abstract class CarBase : ICarBase
	{
		protected string Colour;
		protected string Type;
		protected string Producer;
		public int power;
		public string driver { get; set; }

		public int Power()
		{
			throw new NotImplementedException();
		}

		public void Drive()
		{
			throw new NotImplementedException();
		}
	}
}
