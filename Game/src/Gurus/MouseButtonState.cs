using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	/// <summary>
	/// Purpose: Stores Button and state
	/// </summary>
	public struct MouseButtonState
	{
		public MouseButtonState(MouseButton button, MouseState state)
		{
			Button = button;
			State = state;
		}

		public MouseButton Button
		{
			get;
			set;
		}

		public MouseState State
		{
			get;
			set;
		}
	}
}
