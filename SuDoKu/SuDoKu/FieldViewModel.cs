using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SuDoKu.Annotations;

namespace SuDoKu
{
	public class FieldViewModel : INotifyPropertyChanged
	{
		public readonly Block Block;
		private int _number;

		public int BlockColumn
		{
			get
			{
				return Column - (Block.Column - 1)*3;
			} 
		}

		public int BlockRow
		{
			get
			{
				return Row - (Block.Row - 1) * 3;
			} 
		}

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
		}

		public Dictionary<FieldSurrounders, FieldViewModel> Surrounders { get; private set; }
		public int Column { get; private set; }

		public int Number
		{
			get { return _number; }
			set
			{
				if (!Equals(_number, value) && Block.CheckNumbers(value))
				{
					_number = value;
					OnPropertyChanged(nameof(Number));
				}
			}
		}

		public int Row { get; private set; }

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
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}