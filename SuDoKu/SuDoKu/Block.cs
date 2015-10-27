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

		public List<FieldViewModel> FieldViewModelList { private get; set; }

		public FieldViewModel PositionField1 { get; private set; }
		public FieldViewModel PositionField2 { get; private set; }
		public FieldViewModel PositionField3 { get; private set; }
		public FieldViewModel PositionField4 { get; private set; }
		public FieldViewModel PositionField5 { get; private set; }
		public FieldViewModel PositionField6 { get; private set; }
		public FieldViewModel PositionField7 { get; private set; }
		public FieldViewModel PositionField8 { get; private set; }
		public FieldViewModel PositionField9 { get; private set; }

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

		public void InitializePositionFields()
		{
			PositionField1 = FieldViewModelList.FirstOrDefault(field => field.BlockColumn == 0 && field.BlockRow == 0);
			PositionField2 = FieldViewModelList.FirstOrDefault(field => field.BlockColumn == 1 && field.BlockRow == 0);
			PositionField3 = FieldViewModelList.FirstOrDefault(field => field.BlockColumn == 2 && field.BlockRow == 0);
			PositionField4 = FieldViewModelList.FirstOrDefault(field => field.BlockColumn == 0 && field.BlockRow == 1);
			PositionField5 = FieldViewModelList.FirstOrDefault(field => field.BlockColumn == 1 && field.BlockRow == 1);
			PositionField6 = FieldViewModelList.FirstOrDefault(field => field.BlockColumn == 2 && field.BlockRow == 1);
			PositionField7 = FieldViewModelList.FirstOrDefault(field => field.BlockColumn == 0 && field.BlockRow == 2);
			PositionField8 = FieldViewModelList.FirstOrDefault(field => field.BlockColumn == 1 && field.BlockRow == 2);
			PositionField9 = FieldViewModelList.FirstOrDefault(field => field.BlockColumn == 2 && field.BlockRow == 2);
		}
	}
}