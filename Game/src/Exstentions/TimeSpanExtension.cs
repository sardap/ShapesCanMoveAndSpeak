using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.src
{
	public static class TimeSpanExtension
	{
		public static TimeSpan Multiply(this TimeSpan timespan, double multiplier)
		{
			return TimeSpan.FromTicks(timespan.Ticks * (long)multiplier);
		}
	}
}
