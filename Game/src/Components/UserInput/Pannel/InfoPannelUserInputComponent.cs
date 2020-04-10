using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	/// <summary>
	/// Purpose: Used for a panel Asserts it's position over 
	/// </summary>
	public class PanelUserInputComponent : UserInputComponent
	{
		public PanelUserInputComponent(Shape bounds, GameObject holder) : base(bounds, holder)
		{
		}

		protected override void Action(MouseGuru mouseGuru, KeyboardGuru keyboardGuru)
		{
		}

		// Used to assert dominance over the game world
		protected override void InitliseResponseButtons()
		{
			ReponseButtons = new List<MouseButtonState>
			{
				new MouseButtonState { Button = MouseButton.LeftButton, State = MouseState.Down },
				new MouseButtonState { Button = MouseButton.LeftButton, State = MouseState.Up },
				new MouseButtonState { Button = MouseButton.RightButton, State = MouseState.Clicked }
			};
		}
	}
}
