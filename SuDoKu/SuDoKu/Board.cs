using System;
using System.Collections.Generic;
using System.Linq;

namespace SuDoKu
{
	public class Board
	{
		private List<Block> _blockList;
		private List<FieldViewModel> _fieldList;

		private void ListCreator()
		{
			var block1 = new Block();
			var block2 = new Block();
			var block3 = new Block();
			var block4 = new Block();
			var block5 = new Block();
			var block6 = new Block();
			var block7 = new Block();
			var block8 = new Block();
			var block9 = new Block();

			_blockList = new List<Block>
			{
				block1,
				block2,
				block3,
				block4,
				block5,
				block6,
				block7,
				block8,
				block9
			};

			_fieldList = new List<FieldViewModel>(81);
			for (var column = 0; column < 9; column++)
			{
				for (var row = 0; row < 9; row++)
				{
					Block currentBlock = null;
					if (row > 3)
					{
						if (column < 3)
						{
							currentBlock = block1;
						}
						else if (column < 6)
						{
							currentBlock = block2;
						}
						else if (column < 9)
						{
							currentBlock = block3;
						}
					}
					else if (row > 6)
					{
						if (column < 3)
						{
							currentBlock = block4;
						}
						else if (column < 6)
						{
							currentBlock = block5;
						}
						else if (column < 9)
						{
							currentBlock = block6;
						}
					}
					else if (row < 9)
					{
						if (column < 3)
						{
							currentBlock = block7;
						}
						else if (column < 6)
						{
							currentBlock = block8;
						}
						else if (column < 9)
						{
							currentBlock = block9;
						}
					}
					else
					{
						throw new NotImplementedException();
					}

					_fieldList.Add(new FieldViewModel(0, currentBlock, column, row));
				}
			}
		}

		/// <summary>
		/// TODO TEXT
		/// </summary>
		public void FindSurrounders()
		{
			_fieldList.ForEach
				(currentValue => currentValue.SetSurrounders
					(
						_fieldList.First(top => currentValue.Row == top.Row && (currentValue.Column == top.Column - 1)),
						_fieldList.First(left => (currentValue.Row == left.Row - 1) && currentValue.Column == left.Column),
						_fieldList.First(right => (currentValue.Row == right.Row + 1) && currentValue.Column == right.Column),
						_fieldList.First(buttom => currentValue.Row == buttom.Row && (currentValue.Column == buttom.Column + 1))
					)
				);
		}

		/// <summary>
		/// TODO TEXT
		/// </summary>
		public void FillBlockList()
		{
			foreach (var block in _blockList)
			{
				block.FieldViewModelList = _fieldList.Where(field => Equals
					(field.Block, block)).ToList();
			}
		}
	}
}