using System;
using System.Collections.Generic;
using System.Text;
using Adapter;
using SharedLibary;
using SplashKitSDK;

namespace SplashKitAdapter
{
    public class SplashKitInputAdapter : IInputAdapter
    {
		public SplashKitInputAdapter()
		{
		}

		public SharedLibary.Point2D MousePostion()
		{
			return PointWraper.FromSplashKit(SplashKit.MousePosition());
		}

		public bool KeyDown(SharedLibary.KeyCode key)
		{
			return SplashKit.KeyDown(ToSplashKitKeyCode(key));
		}

		public bool KeyTyped(SharedLibary.KeyCode key)
		{
			return SplashKit.KeyTyped(ToSplashKitKeyCode(key));
		}

		public bool MouseDown(SharedLibary.MouseButton button)
		{
			return SplashKit.MouseDown(ToSplashKitMouseButton(button));
		}

		public bool MouseUp(SharedLibary.MouseButton button)
		{
			return SplashKit.MouseUp(ToSplashKitMouseButton(button));
		}

		public bool MouseClicked(SharedLibary.MouseButton button)
		{
			return SplashKit.MouseClicked(ToSplashKitMouseButton(button));
		}

		private SplashKitSDK.KeyCode ToSplashKitKeyCode(SharedLibary.KeyCode key)
		{
			return (SplashKitSDK.KeyCode)UtilsWraper.KeyCodeToInt(key);
		}

		private SplashKitSDK.MouseButton ToSplashKitMouseButton(SharedLibary.MouseButton button)
		{
			return (SplashKitSDK.MouseButton)UtilsWraper.MouseButtonToInt(button);
		}
	}
}
