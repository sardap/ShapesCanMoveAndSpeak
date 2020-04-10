using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	/// <summary>
	/// Purpose: The reason why Money is not just an int but 
	/// Is an object which holds value is because i intended to attach
	/// disease to certain money objects at random which would infect
	/// the holder and that money could be passed around
	/// </summary>
	public class Money : IComparable
	{
		private int _worth;

		public Money(int worth)
		{
			_worth = worth;
		}

		public int Worth
		{
			get
			{
				return _worth;
			}
		}

		/// <summary>
		/// Purpose: So the Sort method can be used
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public int CompareTo(object obj)
		{
			Money temp = obj as Money;

			if (Worth > temp.Worth)
			{
				return 1;
			}
			else if (Worth < temp.Worth)
			{
				return -1;
			}
			else
			{
				return 0;
			}
		}
	}
}
