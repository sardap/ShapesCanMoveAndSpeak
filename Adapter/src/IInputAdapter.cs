using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Adapter
{
	public interface IInputAdapter
	{
		Point2D MousePostion();

		 bool KeyDown(KeyCode key);

		 bool KeyTyped(KeyCode key);

		 bool MouseDown(MouseButton button);

		 bool MouseUp(MouseButton button);

		 bool MouseClicked(MouseButton button);
	}
}
