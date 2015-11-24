using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasciTest
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
