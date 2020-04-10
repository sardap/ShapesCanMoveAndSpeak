using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.src
{
	public static class IEnumerableExsentions
	{
		private static Random _rnd = new Random();

		public static T RandomElement<T>(this IEnumerable<T> list)
		{
			if(list.Count() == 0)
			{
				return default(T);
			}

			return list.ElementAt(_rnd.Next(list.Count()));
		}
	}
}
