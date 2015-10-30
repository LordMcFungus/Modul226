using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using SuDoKu.Annotations;

namespace SuDoKu
{
	public sealed class Board : INotifyPropertyChanged
	{
		private List<Block> _blockList;

		private List<IFieldViewModel> _fieldList;

		public Board()
		{
			ListCreator();
			FillBlockList();
			FindSurrounders();
		}

		public IEnumerable<Block> BlockList
			=> _blockList ?? (_blockList = new List<Block> {Block1, Block2, Block3, Block4, Block5, Block6, Block7, Block8, Block9});

		public Block Block1 { get; private set; }
		public Block Block2 { get; private set; }
		public Block Block3 { get; private set; }
		public Block Block4 { get; private set; }
		public Block Block5 { get; private set; }
		public Block Block6 { get; private set; }
		public Block Block7 { get; private set; }
		public Block Block8 { get; private set; }
		public Block Block9 { get; private set; }

		public event PropertyChangedEventHandler PropertyChanged;

		private void ListCreator()
		{
			Block1 = new Block(0, 0, 1);
			Block2 = new Block(1, 0, 2);
			Block3 = new Block(2, 0, 3);
			Block4 = new Block(0, 1, 4);
			Block5 = new Block(1, 1, 5);
			Block6 = new Block(2, 1, 6);
			Block7 = new Block(0, 2, 7);
			Block8 = new Block(1, 2, 8);
			Block9 = new Block(2, 2, 9);

			_fieldList = new List<IFieldViewModel>(81);
			for (var column = 0; column < 9; column++)
			{
				for (var row = 0; row < 9; row++)
				{
					Block currentBlock = null;
					if (row < 3)
					{
						if (column < 3)
						{
							currentBlock = Block1;
						}
						else if (column < 6)
						{
							currentBlock = Block2;
						}
						else if (column < 9)
						{
							currentBlock = Block3;
						}
					}
					else if (row < 6)
					{
						if (column < 3)
						{
							currentBlock = Block4;
						}
						else if (column < 6)
						{
							currentBlock = Block5;
						}
						else if (column < 9)
						{
							currentBlock = Block6;
						}
					}
					else if (row < 9)
					{
						if (column < 3)
						{
							currentBlock = Block7;
						}
						else if (column < 6)
						{
							currentBlock = Block8;
						}
						else if (column < 9)
						{
							currentBlock = Block9;
						}
					}
					else
					{
						throw new NotImplementedException();
					}

					_fieldList.Add(new FieldViewModel(0, currentBlock, column, row));
				}
			}
		}

		/// <summary>
		///     TODO TEXT
		/// </summary>
		public void FindSurrounders()
		{
			_fieldList.ForEach
				(currentValue => currentValue.SetSurrounders
					(
						_fieldList.FirstOrDefault(top => currentValue.Row == top.Row && (currentValue.Column == top.Column - 1)),
						_fieldList.FirstOrDefault(left => (currentValue.Row == left.Row - 1) && currentValue.Column == left.Column),
						_fieldList.FirstOrDefault(right => (currentValue.Row == right.Row + 1) && currentValue.Column == right.Column),
						_fieldList.FirstOrDefault(buttom => currentValue.Row == buttom.Row && (currentValue.Column == buttom.Column + 1))
					)
				);
		}

		/// <summary>
		///     TODO TEXT
		/// </summary>
		public void FillBlockList()
		{
			foreach (var block in BlockList)
			{
				block.FieldViewModelList = _fieldList.Where(field => Equals
					(field.Block, block)).ToList();
				OnPropertyChanged(nameof(block));
			}
			foreach (var block in BlockList)
			{
				block.InitializePositionFields();
				OnPropertyChanged(nameof(block));
			}
		}

		[NotifyPropertyChangedInvocator]
		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}