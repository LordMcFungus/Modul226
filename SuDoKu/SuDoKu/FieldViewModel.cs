using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Packaging;
using System.Runtime.CompilerServices;
using SuDoKu.Annotations;

namespace SuDoKu
{
	public sealed class FieldViewModel : IFieldViewModel
	{
		public Block Block { get; }
		public bool IsEditable { get; set; } = true;
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

		private Dictionary<FieldSurrounders, IFieldViewModel> Surrounders { get; set; }

		public string NumberString
		{
			get
			{
				return Number == 0 ? "" : Number.ToString();
			}
			set
			{
				int swag;
                int.TryParse(value, out swag);
				Number = swag;
			}
		}

		public int Number
		{
			get
			{
				return _number;
			}
			set
			{
				if (!Equals(_number, value) && Block.CheckNumbers(value) && value >= 0 && value <=9 && CheckNumbersInBoard(value))
				{
					_number = value;
					OnPropertyChanged(nameof(Number));
				}
			}
		}

		private bool CheckNumbersInBoard(int i)
		{
			if (CheckNumberInBoard(i, FieldSurrounders.Top) && CheckNumberInBoard(i, FieldSurrounders.Right) && CheckNumberInBoard(i, FieldSurrounders.Left) && CheckNumberInBoard(i, FieldSurrounders.Bottom))
			{
				return true;
			}
			return false;
		}

		public bool CheckNumberInBoard(int i, FieldSurrounders direction)
		{
			if (Number == i)
			{
				return false;
			}
			var tmp = Surrounders[direction];
			if (tmp == null)
			{
				return true;
			}
			return tmp.CheckNumberInBoard(i, direction);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="top"></param>
		/// <param name="left"></param>
		/// <param name="right"></param>
		/// <param name="buttom"></param>
		public void SetSurrounders(IFieldViewModel top, IFieldViewModel left, IFieldViewModel right, IFieldViewModel buttom)
		{
			Surrounders = new Dictionary<FieldSurrounders, IFieldViewModel>
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