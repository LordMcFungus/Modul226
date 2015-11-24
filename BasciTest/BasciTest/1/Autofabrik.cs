using System.Collections.Generic;

namespace BasciTest._1
{
	class Autofabrik
	{
		public IEnumerable<Auto> BuildAutos(int amount)
		{
			IList<Auto> autoList = new List<Auto>(amount);

			for (var i = 0; i < amount; i++)
			{
				autoList.Add(new Auto());
			}

			return autoList;
		}
	}
}
