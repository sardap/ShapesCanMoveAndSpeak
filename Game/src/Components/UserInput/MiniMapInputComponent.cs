using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	/// <summary>
	/// Purpose: Handle MiniMap Input from user
	/// </summary>
	public class MiniMapInputComponent : UserInputComponent
	{
		public MiniMapInputComponent(Rectangle bounds, GameObject holder) : base(bounds, holder)
		{
		}

		/// <summary>
		/// Purpose: Moves the camera to the position in the game world relative	
		/// to the MiniMap position
		/// <param name="mouseGuru"></param>
		protected override void Action(MouseGuru mouseGuru, KeyboardGuru keyboardGuru)
		{
			Rectangle newPostion = new Rectangle
			(
				Utils.FromBoundsToWorld(mouseGuru.RawPostion, Bounds),
				Utils.ScreenWidth(),
				Utils.ScreenHeight()
			);

			newPostion.X = Math.Abs(newPostion.X - Utils.ScreenWidth() / 2);
			newPostion.Y = Math.Abs(newPostion.Y - Utils.ScreenHeight() / 2);

			if (Utils.InsideGameBounds(newPostion))
			{
				Utils.SetCamreaPostion(newPostion);
			}
		}

		protected override void InitliseResponseButtons()
		{
			ReponseButtons = new List<MouseButtonState>
			{
				new MouseButtonState { Button = MouseButton.LeftButton, State = MouseState.Down }
			};
		}
	}
}
