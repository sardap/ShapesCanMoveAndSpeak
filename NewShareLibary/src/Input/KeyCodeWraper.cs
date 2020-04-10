using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibary
{ 
	/// <summary>
	/// Used to get the int value from KeyCodes and Mousebuttons
	/// Becuase of issue with .NET versions
	/// </summary>
	public static class UtilsWraper
	{
		public static int KeyCodeToInt(KeyCode key)
		{
			return (int)key;
		}

		public static int MouseButtonToInt(MouseButton button)
		{
			return (int)button;
		}
	}
}
