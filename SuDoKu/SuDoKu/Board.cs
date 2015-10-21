using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuDoKu
{
	public class Board
	{

		private List<FieldVievModel> fieldList;
		private List<Block> blockList;
		private void listCreator()
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

			blockList = new List<Block>
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

			fieldList = new List<FieldVievModel>(81);
			for (int column = 0; column < 9; column++)
			{

				for (int row = 0; row<9;row++)
				{
					Block currentBlock = null;
					if(row > 3)
					{
						if (column < 3 /*&& row < 3*/)
						{
							currentBlock = block1;
						}
						else if (column < 6 /*&& (row < 3)*/)
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
						if (column < 3 /*&& row < 3*/)
						{
							currentBlock = block4;
						}
						else if (column < 6 /*&& (row < 3)*/)
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
						if (column < 3 /*&& row < 3*/)
						{
							currentBlock = block7;
						}
						else if (column < 6 /*&& (row < 3)*/)
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

					fieldList.Add(new FieldVievModel(0, currentBlock, column, row));
				}

			}
		}

		public void findSurrounders()
		{
			fieldList.ForEach
				(currentValue => currentValue.setSurrounders
					(
						fieldList.First(top => currentValue.Row == top.Row && (currentValue.Column == top.Column - 1)),
                        fieldList.First(left => (currentValue.Row == left.Row - 1) && currentValue.Column == left.Column),
						fieldList.First(right => (currentValue.Row == right.Row + 1) && currentValue.Column == right.Column),
						fieldList.First(buttom => currentValue.Row == buttom.Row && (currentValue.Column == buttom.Column + 1))
			
					)
			
			
			);
		}

		public void fillBlockList()
		{
			blockList.ForEach
				(currentValue => currentValue.fillList
					(
						fieldList.FindAll(field => currentValue  = field._block)
					)


				);
		}
	}
}

/*	{
				new FieldVievModel(0, block1),
				new FieldVievModel(0, block1),
				new FieldVievModel(0, block1),
				new FieldVievModel(0, block1),
				new FieldVievModel(0, block1),
				new FieldVievModel(0, block1),
				new FieldVievModel(0, block1),
				new FieldVievModel(0, block1),
				new FieldVievModel(0, block1),

				new FieldVievModel(0, block2),
				new FieldVievModel(0, block2),
				new FieldVievModel(0, block2),
				new FieldVievModel(0, block2),
				new FieldVievModel(0, block2),
				new FieldVievModel(0, block2),
				new FieldVievModel(0, block2),
				new FieldVievModel(0, block2),
				new FieldVievModel(0, block2),

				new FieldVievModel(0, block3),
				new FieldVievModel(0, block3),
				new FieldVievModel(0, block3),
				new FieldVievModel(0, block3),
				new FieldVievModel(0, block3),
				new FieldVievModel(0, block3),
				new FieldVievModel(0, block3),
				new FieldVievModel(0, block3),
				new FieldVievModel(0, block3),

				new FieldVievModel(0, block4),
				new FieldVievModel(0, block4),
				new FieldVievModel(0, block4),
				new FieldVievModel(0, block4),
				new FieldVievModel(0, block4),
				new FieldVievModel(0, block4),
				new FieldVievModel(0, block4),
				new FieldVievModel(0, block4),
				new FieldVievModel(0, block4),

				new FieldVievModel(0, block5),
				new FieldVievModel(0, block5),
				new FieldVievModel(0, block5),
				new FieldVievModel(0, block5),
				new FieldVievModel(0, block5),
				new FieldVievModel(0, block5),
				new FieldVievModel(0, block5),
				new FieldVievModel(0, block5),
				new FieldVievModel(0, block5),

				new FieldVievModel(0, block6),
				new FieldVievModel(0, block6),
				new FieldVievModel(0, block6),
				new FieldVievModel(0, block6),
				new FieldVievModel(0, block6),
				new FieldVievModel(0, block6),
				new FieldVievModel(0, block6),
				new FieldVievModel(0, block6),
				new FieldVievModel(0, block6),

				new FieldVievModel(0, block7),
				new FieldVievModel(0, block7),
				new FieldVievModel(0, block7),
				new FieldVievModel(0, block7),
				new FieldVievModel(0, block7),
				new FieldVievModel(0, block7),
				new FieldVievModel(0, block7),
				new FieldVievModel(0, block7),
				new FieldVievModel(0, block7),

				new FieldVievModel(0, block8),
				new FieldVievModel(0, block8),
				new FieldVievModel(0, block8),
				new FieldVievModel(0, block8),
				new FieldVievModel(0, block8),
				new FieldVievModel(0, block8),
				new FieldVievModel(0, block8),
				new FieldVievModel(0, block8),
				new FieldVievModel(0, block8),

				new FieldVievModel(0, block9),
				new FieldVievModel(0, block9),
				new FieldVievModel(0, block9),
				new FieldVievModel(0, block9),
				new FieldVievModel(0, block9),
				new FieldVievModel(0, block9),
				new FieldVievModel(0, block9),
				new FieldVievModel(0, block9),
				new FieldVievModel(0, block9),


			};
*/