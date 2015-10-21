using System.Collections.Generic;

namespace SuDoKu
{
	public class FieldViewModel
	{
		public readonly Block Block;
		private Dictionary<FieldSurrounders, FieldViewModel> _surrounders;

		/// <summary>
		/// TODO TEXT
		/// </summary>
		/// <param name="defaultValue">TODO TEXT</param>
		/// <param name="block">TODO TEXT</param>
		/// <param name="column">TODO TEXT</param>
		/// <param name="row">TODO TEXT</param>
		public FieldViewModel(int defaultValue, Block block, int column, int row)
		{
			Block = block;
			Column = column;
			Row = row;
			Number = defaultValue;
		}

		public int Column { get; private set; }
		public int Row { get; private set; }

		public int Number { get; private set; }

		public void SetSurrounders(FieldViewModel top, FieldViewModel left, FieldViewModel right, FieldViewModel buttom)
		{
			_surrounders = new Dictionary<FieldSurrounders, FieldViewModel>
			{
				{FieldSurrounders.Bottom, buttom},
				{FieldSurrounders.Left, left},
				{FieldSurrounders.Top, top},
				{FieldSurrounders.Right, right}
			};
		}
	}
}