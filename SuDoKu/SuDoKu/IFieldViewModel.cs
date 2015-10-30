using System.ComponentModel;

namespace SuDoKu
{
	/// <summary>
	/// Interface for the FieldViewModel
	/// </summary>
	public interface IFieldViewModel : INotifyPropertyChanged
	{
		/// <summary>
		/// Instance of the Block, which contains this field
		/// </summary>
		Block Block { get; }
		/// <summary>
		/// Column of the field in the Block, beginns at 0
		/// </summary>
		int BlockColumn { get; }
		/// <summary>
		/// Row of the Field in the Block, beginns at 0
		/// </summary>
		int BlockRow { get; }
		/// <summary>
		/// Column of the Field in the board, beginns at 0
		/// </summary>
		int Column { get; }
		/// <summary>
		/// Bool if the Field is a pre-given one, or must be changed
		/// </summary>
		bool IsEditable { get; set; }
		/// <summary>
		/// Number of the field 1 to 9
		/// </summary>
		int Number { get; set; }
		/// <summary>
		/// String of the number of the Field for better GUI
		/// </summary>
		string NumberString { get; set; }
		/// <summary>
		/// Row of the field in the board, beginns at 0
		/// </summary>
		int Row { get; }

		/// <summary>
		/// checks if the number is already used in the field's row, and column
		/// </summary>
		/// <param name="i">Number to check</param>
		/// <param name="direction">Direction, Top, Left, Right, Buttom</param>
		/// <returns></returns>
		bool CheckNumberInBoard(int i, FieldSurrounders direction);

		/// <summary>
		/// Set the surrounding fields of this field
		/// </summary>
		/// <param name="top">Field on top, row - 1</param>
		/// <param name="left">Field at left, column - 1</param>
		/// <param name="right">Field at right, column + 1</param>
		/// <param name="buttom">Field at the button, row + 1</param>
		void SetSurrounders(IFieldViewModel top, IFieldViewModel left, IFieldViewModel right, IFieldViewModel buttom);
	}
}