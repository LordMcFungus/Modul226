using System.Collections.Generic;
using System.Linq;

namespace SuDoKu
{
	public class Block
	{
		public List<FieldViewModel> FieldViewModelList { private get; set; }

		private IEnumerable<int> FieldNumbers
		{
			get { return FieldViewModelList.Select(o => o.Number).Where(num => num > 0 && num < 10).ToList(); }
		}

		/// <summary>
		///     TODO TEXT
		/// </summary>
		/// <param name="i">TODO TEXT</param>
		/// <returns></returns>
		public bool CheckNumbers(int i)
		{
			return FieldNumbers.All(num => num != i);
		}
	}
}