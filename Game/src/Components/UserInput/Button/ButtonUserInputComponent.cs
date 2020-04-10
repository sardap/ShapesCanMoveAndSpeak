using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	public abstract class ButtonUserInputComponent : UserInputComponent
	{
		public ButtonUserInputComponent(Rectangle bounds, GameObject holder) : base(bounds, holder)
		{
		}

		protected override void InitliseResponseButtons()
		{
			ReponseButtons = new List<MouseButtonState>
			{
				new MouseButtonState(MouseButton.LeftButton, MouseState.Clicked)
			};
		}
	}
}
