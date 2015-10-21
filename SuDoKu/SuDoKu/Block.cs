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

		public void fillList(List<FieldVievModel> list)
		{
			FieldViewModelList = list;
			
			/*FieldViewModelList = new List<FieldVievModel>
			{
				field1,
				field2,
				field3,
				field4,
				field5,
				field6,
				field7,
				field8,
				field9
			};*/
		}
	}
}