using System;
using System.Linq;

namespace SuDoKu
{
	public class BoardFactory
	{
		Board _board;
		private Block _currentBlock;

		public BoardFactory()
		{
			_board = new Board();
		}

		public BoardFactory SelectBlock(int blockIndex)
		{
			_currentBlock = _board.BlockList.FirstOrDefault(b => b.blockIndex == blockIndex);
			return this;
		}

		public BoardFactory SetNumbersToBlock(int i, int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8)
		{
			_currentBlock.PositionField1.IsEditable = (_currentBlock.PositionField1.Number = i) == 0; 
			_currentBlock.PositionField2.IsEditable = (_currentBlock.PositionField2.Number = i1) == 0; 
			_currentBlock.PositionField3.IsEditable = (_currentBlock.PositionField3.Number = i2) == 0; 
			_currentBlock.PositionField4.IsEditable = (_currentBlock.PositionField4.Number = i3) == 0; 
			_currentBlock.PositionField5.IsEditable = (_currentBlock.PositionField5.Number = i4) == 0; 
			_currentBlock.PositionField6.IsEditable = (_currentBlock.PositionField6.Number = i5) == 0; 
			_currentBlock.PositionField7.IsEditable = (_currentBlock.PositionField7.Number = i6) == 0; 
			_currentBlock.PositionField8.IsEditable = (_currentBlock.PositionField8.Number = i7) == 0; 
			_currentBlock.PositionField9.IsEditable = (_currentBlock.PositionField9.Number = i8) == 0; 
			return this;
		}

		public Board Create()
		{
			return _board;
		}
	}
}