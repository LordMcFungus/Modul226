using System;
using NUnit.Framework;
using SuDoKu;

namespace SuDoKuTest
{
	[TestFixture]
	public class GeneralModuleTest
	{
		private Board board;

		[Test]
		public void WhenGivenInvalidInputNumberIsNotSaved()
		{
			// Arrange
			board = new Board();

			// Act
			board.Block1.PositionField1.Number = 2341324;
			board.Block1.PositionField2.NumberString = "34123";
			board.Block1.PositionField3.NumberString = "adfdfas";
			board.Block1.PositionField4.Number = int.MaxValue;
			board.Block1.PositionField5.Number = int.MinValue;
			board.Block1.PositionField6.Number = 0;
			board.Block1.PositionField7.Number = 10;
			board.Block1.PositionField8.Number = 9;
			board.Block1.PositionField9.Number = 1;
			board.Block2.PositionField9.Number = 5;

			// Assert
			Assert.That(board.Block1.PositionField1.NumberString, Is.Null.Or.Empty);
			Assert.That(board.Block1.PositionField2.NumberString, Is.Null.Or.Empty);
			Assert.That(board.Block1.PositionField3.NumberString, Is.Null.Or.Empty);
			Assert.That(board.Block1.PositionField4.NumberString, Is.Null.Or.Empty);
			Assert.That(board.Block1.PositionField5.NumberString, Is.Null.Or.Empty);
			Assert.That(board.Block1.PositionField6.NumberString, Is.Null.Or.Empty);
			Assert.That(board.Block1.PositionField7.NumberString, Is.Null.Or.Empty);
			Assert.That(board.Block1.PositionField8.NumberString, Is.EqualTo("9"));
			Assert.That(board.Block1.PositionField9.NumberString, Is.EqualTo("1"));
			Assert.That(board.Block2.PositionField9.NumberString, Is.EqualTo("5"));
		}
		[Test]
		public void WhenNumberIsAlreadyInBlockNumberIsNotSaved()
		{
			// Arrange
			board = new Board();

			//Act
			board.Block1.PositionField1.Number = 1;
			board.Block1.PositionField2.Number = 2;
			board.Block1.PositionField3.Number = 3;
			board.Block1.PositionField4.Number = 3;

			//Assert
			Assert.That(board.Block1.PositionField1.NumberString, Is.EqualTo("1"));
			Assert.That(board.Block1.PositionField2.NumberString, Is.EqualTo("2"));
			Assert.That(board.Block1.PositionField3.NumberString, Is.EqualTo("3"));
			Assert.That(board.Block1.PositionField4.NumberString, Is.Null.Or.Empty);
		}
		[Test]
		public void WhenNumberIsAlreadyInRowNumberIsNull()
		{
			// Arrange
			board = new Board();

			//Act
			board.Block1.PositionField1.Number = 1;
			board.Block2.PositionField1.Number = 3;
			board.Block3.PositionField1.Number = 2;
			board.Block3.PositionField2.Number = 3;

			//Assert
			Assert.That(board.Block1.PositionField1.NumberString, Is.EqualTo("1"));
			Assert.That(board.Block2.PositionField1.NumberString, Is.EqualTo("3"));
			Assert.That(board.Block3.PositionField1.NumberString, Is.EqualTo("2"));
			Assert.That(board.Block3.PositionField2.NumberString, Is.Null.Or.Empty);
		}
		[Test]
		public void WhenNumberIsAlreadyInColumnNuberIsNull()
		{
			// Arrange
			board = new Board();

			//Act
			board.Block1.PositionField1.Number = 1;
			board.Block4.PositionField1.Number = 3;
			board.Block7.PositionField1.Number = 2;
			board.Block7.PositionField4.Number = 3;

			//Assert
			Assert.That(board.Block1.PositionField1.NumberString, Is.EqualTo("1"));
			Assert.That(board.Block4.PositionField1.NumberString, Is.EqualTo("3"));
			Assert.That(board.Block7.PositionField1.NumberString, Is.EqualTo("2"));
			Assert.That(board.Block7.PositionField4.NumberString, Is.Null.Or.Empty);
		}

		[Test]
		public void TestBoardFactory()
		{
			// Arrange
			board = new Board();
			var factoryBoard = new BoardFactory().SelectBlock(1).SetNumbersToBlock(0, 0, 0, 0, 8, 0, 0, 0, 0)
				.SelectBlock(2).SetNumbersToBlock(0, 4, 0, 0, 0, 0, 0, 0, 0)
				.SelectBlock(3).SetNumbersToBlock(0, 0, 0, 0, 0, 0, 0, 4, 0)
				.SelectBlock(4).SetNumbersToBlock(0, 0, 0, 0, 0, 0, 5, 0, 0)
				.SelectBlock(5).SetNumbersToBlock(0, 0, 0, 4, 0, 0, 0, 0, 0)
				.SelectBlock(6).SetNumbersToBlock(5, 0, 0, 0, 0, 0, 0, 0, 0)
				.SelectBlock(7).SetNumbersToBlock(0, 0, 1, 0, 0, 0, 0, 0, 0)
				.SelectBlock(8).SetNumbersToBlock(0, 0, 0, 0, 0, 6, 0, 0, 0)
				.SelectBlock(9).SetNumbersToBlock(0, 0, 0, 0, 0, 9, 0, 0, 0)
				.Create();

			//Act
			board.Block1.PositionField5.Number = 8;
			board.Block2.PositionField2.Number = 4;
			board.Block3.PositionField8.Number = 4;
			board.Block4.PositionField7.Number = 5;
			board.Block5.PositionField4.Number = 4;
			board.Block6.PositionField1.Number = 5;
			board.Block7.PositionField3.Number = 1;
			board.Block8.PositionField6.Number = 6;
			board.Block9.PositionField6.Number = 9;

			//Assert
			Assert.That(factoryBoard.Block1.PositionField5.NumberString, Is.EqualTo(board.Block1.PositionField5.NumberString));
			Assert.That(factoryBoard.Block1.PositionField2.NumberString, Is.EqualTo(board.Block1.PositionField2.NumberString));
			Assert.That(factoryBoard.Block1.PositionField8.NumberString, Is.EqualTo(board.Block1.PositionField8.NumberString));
			Assert.That(factoryBoard.Block1.PositionField7.NumberString, Is.EqualTo(board.Block1.PositionField7.NumberString));
			Assert.That(factoryBoard.Block1.PositionField4.NumberString, Is.EqualTo(board.Block1.PositionField4.NumberString));
			Assert.That(factoryBoard.Block1.PositionField1.NumberString, Is.EqualTo(board.Block1.PositionField1.NumberString));
			Assert.That(factoryBoard.Block1.PositionField3.NumberString, Is.EqualTo(board.Block1.PositionField3.NumberString));
			Assert.That(factoryBoard.Block1.PositionField6.NumberString, Is.EqualTo(board.Block1.PositionField6.NumberString));
			Assert.That(factoryBoard.Block1.PositionField6.NumberString, Is.EqualTo(board.Block1.PositionField6.NumberString));
		}
	}
}
