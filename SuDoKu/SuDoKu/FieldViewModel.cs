using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SuDoKu.Annotations;

namespace SuDoKu
{
	public sealed class FieldViewModel : INotifyPropertyChanged
	{
		public readonly Block Block;
		private int _number;
		public int Row { get; }
		public int Column { get; }
		public int BlockColumn
		{
			get;
		}

		public int BlockRow { get; }

		/// <summary>
		///     TODO TEXT
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

			BlockRow = Row - Block.Row * 3;
			BlockColumn = Column - Block.Column * 3;
		}

		private Dictionary<FieldSurrounders, FieldViewModel> Surrounders { get; set; }
		

		public int Number
		{
			get { return _number; }
			set
			{
				if (!Equals(_number, value) && Block.CheckNumbers(value) && value >= 0 && value <=9)
				{
					_number = value;
					OnPropertyChanged(nameof(Number));
				}
			}
		}



		public void SetSurrounders(FieldViewModel top, FieldViewModel left, FieldViewModel right, FieldViewModel buttom)
		{
			Surrounders = new Dictionary<FieldSurrounders, FieldViewModel>
			{
				{FieldSurrounders.Bottom, buttom},
				{FieldSurrounders.Left, left},
				{FieldSurrounders.Top, top},
				{FieldSurrounders.Right, right}
			};
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}