using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuDoKu
{
	public class FieldVievModel
	{
		public int Column {	get; private set; }
		public int Row {	get; private set; }
	Dictionary<FieldSurrounders, FieldVievModel> surrounders;
		private Block _block;

		public int Number { get; private set; }

		public FieldVievModel(int defaultValue, Block block, int column, int row)
		{
			_block = block;
			Column = column;
			Row = row;
			 
		}

		
		public void setSurrounders(FieldVievModel top, FieldVievModel left, FieldVievModel right, FieldVievModel buttom)
		{
			surrounders = new Dictionary<FieldSurrounders, FieldVievModel>
			{
				{ FieldSurrounders.buttom, buttom },
				{ FieldSurrounders.left, left},
				{ FieldSurrounders.top, top },
				{ FieldSurrounders.right, right }
			};
        }
	}
}