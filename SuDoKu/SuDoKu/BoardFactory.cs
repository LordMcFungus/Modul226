using System;
using System.Linq;

namespace SuDoKu
{
	/// <summary>
	/// Initializes a Board wit all re-given Numbers
	/// </summary>
	public class BoardFactory
	{
		readonly Board _board;
		private Block _currentBlock;

		/// <summary>
		/// Constructor of the BorârdFactory
		/// </summary>
		public BoardFactory()
		{
			_board = new Board();
		}

		/// <summary>
		/// Selcts the block to fill with the blockindex
		/// </summary>
		/// <param name="blockIndex">Index Of the Block; On which place the Block is in the Board</param>
		/// <returns></returns>
		public BoardFactory SelectBlock(int blockIndex)
		{
			_currentBlock = _board.BlockList.FirstOrDefault(b => b.BlockIndex == blockIndex);
			return this;
		}

		/// <summary>
		/// Fills the Block with the pre-given Numbers, From top left to buttom right
		/// </summary>
		/// <param name="i">Number 1</param>
		/// <param name="i1">Number 2</param>
		/// <param name="i2">Number 3</param>
		/// <param name="i3">Number 4</param>
		/// <param name="i4">Number 5</param>
		/// <param name="i5">Number 6</param>
		/// <param name="i6">Number 7</param>
		/// <param name="i7">Number 8</param>
		/// <param name="i8">Number 9</param>
		/// <returns></returns>
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

		/// <summary>
		/// Creates the "Factorized" Board
		/// </summary>
		/// <returns></returns>
		public Board Create()
		{
			return _board;
		}
	}
}