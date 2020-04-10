using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	/// <summary>
	/// Purpose: Stores the age of an object
	/// </summary>
	public class Age : IHaveUpdate
	{
		private long _milSecoundsAlive = 0;

		public Age()
		{
		}

		public long Value
		{
			get
			{
				return _milSecoundsAlive / Settings.AGE_DIVSOR;
			}
		}

		public void Update(long deltaTime)
		{
			_milSecoundsAlive += deltaTime;
		}
	}
}
