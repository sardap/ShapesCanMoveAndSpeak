using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;
using SwinGameSDK;
using Adapter;

namespace SwinGameAdapter
{
	public class SwinGameInputAdapter : IInputAdapter
	{
		public SwinGameInputAdapter()
		{
		}

		public SharedLibary.Point2D MousePostion()
		{
			return PointWraper.FromPoint2D(SwinGame.MousePosition());
		}

		public bool KeyDown(SharedLibary.KeyCode key)
		{
			return SwinGame.KeyDown(ToSwinGameKeyCode(key));
		}

		public bool KeyTyped(SharedLibary.KeyCode key)
		{
			return SwinGame.KeyTyped(ToSwinGameKeyCode(key));
		}
		 
		public bool MouseDown(SharedLibary.MouseButton button)
		{
			return SwinGame.MouseDown(ToSwinGameMouseButton(button));
		}

		public bool MouseUp(SharedLibary.MouseButton button)
		{
			return SwinGame.MouseUp(ToSwinGameMouseButton(button));
		}

		public bool MouseClicked(SharedLibary.MouseButton button)
		{
			return SwinGame.MouseClicked(ToSwinGameMouseButton(button));
		}

		private SwinGameSDK.KeyCode ToSwinGameKeyCode(SharedLibary.KeyCode key)
		{
			return (SwinGameSDK.KeyCode)(int)key;
		}

		private SwinGameSDK.MouseButton ToSwinGameMouseButton(SharedLibary.MouseButton button)
		{
			return (SwinGameSDK.MouseButton)(int)button;
		}
	}
}
