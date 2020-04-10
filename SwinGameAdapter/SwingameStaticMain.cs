using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinGameStaticMain
{
	/// <summary>
	/// Swingame Need a static Main Never used crashes program if used somehow
	/// </summary>
	public class SwingameStaticMain
	{
		public static void Main()
		{
			throw new Exception("Swingame Needs a static main even when it's a class libary");
		}
	}
}
