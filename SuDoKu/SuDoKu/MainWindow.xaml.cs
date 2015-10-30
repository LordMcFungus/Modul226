using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SuDoKu
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		/// <summary>
		/// Main Window of the Gui
		/// </summary>
		public MainWindow()
		{
			InitializeComponent();
			DataContext = new BoardFactory().SelectBlock(1).SetNumbersToBlock(0, 0, 2, 0, 8, 0, 0, 0, 0)
				.SelectBlock(2).SetNumbersToBlock(0, 4, 0, 0, 0, 0, 0, 0, 0)
				.SelectBlock(3).SetNumbersToBlock(0, 0, 8, 0, 0, 3, 0, 4, 0)
				.SelectBlock(4).SetNumbersToBlock(3, 0, 0, 0, 0, 0, 5, 0, 0)
				.SelectBlock(5).SetNumbersToBlock(8, 2, 0, 4, 9, 0, 6, 0, 0)
				.SelectBlock(6).SetNumbersToBlock(5, 0, 0, 0, 0, 6, 0, 9, 0)
				.SelectBlock(7).SetNumbersToBlock(0, 5, 1, 0, 0, 0, 4, 0, 0)
				.SelectBlock(8).SetNumbersToBlock(0, 0, 0, 0, 0, 6, 0, 0, 0)
				.SelectBlock(9).SetNumbersToBlock(8, 3, 0, 0, 1, 9, 0, 0, 0)
				.Create();
		}
	}
}
