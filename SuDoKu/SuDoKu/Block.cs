using System.Collections.Generic;
using System.Linq;

namespace SuDoKu
{
	
	/// <summary>
	/// A 3x3 Block which contains 9 Fields
	/// </summary>
	public class Block
	{
		/// <summary>
		/// The wievilti Block this is, starts at one
		/// </summary>
		public readonly int BlockIndex;
		/// <summary>
		/// Constructeur of ze Block
		/// </summary>
		/// <param name="column">Which column, starts at 0</param>
		/// <param name="row">which row, starts at 0</param>
		/// <param name="blockIndex">Which block starts at 1</param>
		public Block(int column, int row, int blockIndex)
		{
			Column = column;
			Row = row;
			BlockIndex = blockIndex;
		}

		/// <summary>
		/// List of the Fields, which this block contains
		/// </summary>
		public List<IFieldViewModel> FieldViewModelList { private get; set; }

		/// <summary>
		/// Firts Field in the Block, from top Right to Buttom Left
		/// </summary>
		public IFieldViewModel PositionField1 { get; private set; }
		/// <summary>
		/// Second Field in the Block, from top Right to Buttom Left
		/// </summary>
		public IFieldViewModel PositionField2 { get; private set; }
		/// <summary>
		/// Third Field in the Block, from top Right to Buttom Left
		/// </summary>
		public IFieldViewModel PositionField3 { get; private set; }
		/// <summary>
		/// fourth Field in the Block, from top Right to Buttom Left
		/// </summary>
		public IFieldViewModel PositionField4 { get; private set; }
		/// <summary>
		/// fifth Field in the Block, from top Right to Buttom Left
		/// </summary>
		public IFieldViewModel PositionField5 { get; private set; }
		/// <summary>
		/// sixth Field in the Block, from top Right to Buttom Left
		/// </summary>
		public IFieldViewModel PositionField6 { get; private set; }
		/// <summary>
		/// seventh Field in the Block, from top Right to Buttom Left
		/// </summary>
		public IFieldViewModel PositionField7 { get; private set; }
		/// <summary>
		/// eighth Field in the Block, from top Right to Buttom Left
		/// </summary>
		public IFieldViewModel PositionField8 { get; private set; }
		/// <summary>
		/// nineth Field in the Block, from top Right to Buttom Left
		/// </summary>
		public IFieldViewModel PositionField9 { get; private set; }

		/// <summary>
		/// Column of the Block in the Board, starts at 0
		/// </summary>
		public int Column { get; private set; }
		/// <summary>
		/// Row of the block in the Board, Starts at 0
		/// </summary>
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
			return FieldNumbers.All(num => num != i || i == 0);
		}

		/// <summary>
		/// Initializes the fields of the Block, with their BlockColumns, and BlockRows
		/// </summary>
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