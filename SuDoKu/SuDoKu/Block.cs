using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuDoKu
{
	public class Block
	{
		public List<FieldVievModel> FieldViewModelList{get;set;}
		public List<int> FieldNumbers
		{
			get
			{
				return FieldViewModelList.Select(o => o.Number).Where(num => num > 0 && num < 10).ToList();
			}
		}
		public bool checkNumbers(int i)
		{
			return FieldNumbers.All(num => num != i);
		}
	}
}