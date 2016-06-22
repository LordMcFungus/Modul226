using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Packaging;
using System.Runtime.CompilerServices;
using SuDoKu.Annotations;

namespace SuDoKu
{
	/// <summary>
	/// Viewmodel of a Single FIeld in the Board
	/// </summary>
	public sealed class FieldViewModel : IFieldViewModel
	{
		/// <summary>
		/// Instance of a 9x9 Block which contains this field
		/// </summary>
		public Block Block { get; }
		/// <summary>
		/// Bool for definig if this field is a Pre-Given Value
		/// </summary>
		public bool IsEditable { get; set; } = true;
		private int _number;
		/// <summary>
		/// Row of the Field in the Board
		/// </summary>
		public int Row { get; }
		/// <summary>
		/// Column of the Field in the Board
		/// </summary>
		public int Column { get; }
		/// <summary>
		/// Column of the Field in the Block
		/// </summary>
		public int BlockColumn
		{
			get;
		}

		/// <summary>
		/// Row of the field in the Block
		/// </summary>
		public int BlockRow { get; }

		/// <summary>
		///  Constructor of the FieldViewModel
		/// </summary>
		/// <param name="defaultValue">Value of the Field</param>
		/// <param name="block">Block which contains this Field</param>
		/// <param name="column">Column of the Field in the Board</param>
		/// <param name="row">Row of the Field in the Board</param>
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

		/// <summary>
		/// String to make possible that value is Null
		/// </summary>
		public string NumberString
		{
			get
			{
				return Number == 0 ? string.Empty : Number.ToString();
			}
			set
			{
				int swag;
                int.TryParse(value, out swag);
				Number = swag;
			}
		}

		/// <summary>
		/// Variable for the Number, Setter is checking for validity
		/// </summary>
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

		/// <summary>
		/// Checks if ¨the typed in Number is already set in the board
		/// </summary>
		/// <param name="i"></param>
		/// <param name="direction"></param>
		/// <returns></returns>
		public bool CheckNumberInBoard(int i, FieldSurrounders direction)
		{
			if (Number == i)
			{
				return false;
			}
			if(i == 0)
			{
				return true;
			}
			var tmp = Surrounders[direction];
			if (tmp == null)
			{
				return true;
			}
			return tmp.CheckNumberInBoard(i, direction);
		}

		/// <summary>
		/// Setter for setting the fields which surround the current field
		/// </summary>
		/// <param name="top">Field on Top</param>
		/// <param name="left">Field at left</param>
		/// <param name="right">Field at Right</param>
		/// <param name="buttom">Field at Buttom</param>
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

		/// <summary>
		/// Event that fires once the property has changed
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}