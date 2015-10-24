using System.Collections.Generic;
using System.Linq;

namespace SuDoKu
{
	public class Block
	{
		public Block(int column, int row)
		{
			Column = column;
			Row = row;
		}

		public List<FieldViewModel> FieldViewModelList { private get; set; } = new List<FieldViewModel>();

		public FieldViewModel FieldIHatePascal1
		{
			get { return FieldViewModelList.FirstOrDefault(field => field.BlockColumn == 1 && field.BlockColumn == 1); }
		}
		public FieldViewModel FieldIHatePascal2
		{
			get { return FieldViewModelList.FirstOrDefault(field => field.BlockColumn == 1 && field.BlockColumn == 2); }
		}
		public FieldViewModel FieldIHatePascal3
		{
			get { return FieldViewModelList.FirstOrDefault(field => field.BlockColumn == 1 && field.BlockColumn == 3); }
		}
		public FieldViewModel FieldIHatePascal4
		{
			get { return FieldViewModelList.FirstOrDefault(field => field.BlockColumn == 2 && field.BlockColumn == 1); }
		}
		public FieldViewModel FieldIHatePascal5
		{
			get { return FieldViewModelList.FirstOrDefault(field => field.BlockColumn == 2 && field.BlockColumn == 2); }
		}
		public FieldViewModel FieldIHatePascal6
		{
			get { return FieldViewModelList.FirstOrDefault(field => field.BlockColumn == 2 && field.BlockColumn == 3); }
		}
		public FieldViewModel FieldIHatePascal7
		{
			get { return FieldViewModelList.FirstOrDefault(field => field.BlockColumn == 3 && field.BlockColumn == 1); }
		}
		public FieldViewModel FieldIHatePascal8
		{
			get { return FieldViewModelList.FirstOrDefault(field => field.BlockColumn == 3 && field.BlockColumn == 2); }
		}
		public FieldViewModel FieldIHatePascal9
		{
			get { return FieldViewModelList.FirstOrDefault(field => field.BlockColumn == 3 && field.BlockColumn == 3); }
		}

		public int Column { get; private set; }
		public int Row { get; private set; }

		private IEnumerable<int> FieldNumbers
		{
			get { return FieldViewModelList.Select(o => o.Number).Where(num => num > 0 && num < 10).ToList(); }
		}
		
		/// <summary>
		///     Checks if Number is already used in the Block
		/// </summary>
		/// <param name="i">Number To Check</param>
		/// <returns></returns>
		public bool CheckNumbers(int i)
		{
			return FieldNumbers.All(num => num != i);
		}

		public void setPascals()
		{
			
		}
	}
}