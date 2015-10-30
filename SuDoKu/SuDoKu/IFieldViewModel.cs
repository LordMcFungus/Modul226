using System.ComponentModel;

namespace SuDoKu
{
	public interface IFieldViewModel : INotifyPropertyChanged
	{
		Block Block { get; }
		int BlockColumn { get; }
		int BlockRow { get; }
		int Column { get; }
		bool IsEditable { get; set; }
		int Number { get; set; }
		string NumberString { get; set; }
		int Row { get; }

		bool CheckNumberInBoard(int i, FieldSurrounders direction);

		void SetSurrounders(IFieldViewModel top, IFieldViewModel left, IFieldViewModel right, IFieldViewModel buttom);
	}
}