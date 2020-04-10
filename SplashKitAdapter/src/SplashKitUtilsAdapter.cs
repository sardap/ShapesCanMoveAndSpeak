using System;
using System.Collections.Generic;
using System.Text;
using SharedLibary;
using Adapter;
using SplashKitSDK;

namespace SplashKitAdapter
{
    public class SplashKitUtilsAdapter : IUtilsAdapter
    {
		public SplashKitUtilsAdapter()
		{
		}

		public bool WindowCloseRequested
		{
			get
			{
				return SplashKit.WindowCloseRequested(SplashKitManager.GraphicsWindow);
			}
		}

		public void OpenGraphicsWindow(string title, int width, int height)
		{
			SplashKitManager.GraphicsWindow = SplashKitSDK.SplashKit.OpenWindow(title, width, height);
		}

		public float ToWorldX(float x)
		{
			return SplashKit.ToWorldX(x);
		}

		public float ToWorldY(float y)
		{
			return SplashKit.ToWorldY(y);
		}

		public SharedLibary.Point2D ToWorld(SharedLibary.Point2D point)
		{
			return PointWraper.FromSplashKit(SplashKit.ToWorld(PointWraper.ToSplashKit(point)));
		}

		public int ScreenWidth()
		{
			return SplashKit.ScreenWidth();
		}

		public int ScreenHeight()
		{
			return SplashKit.ScreenHeight();
		}

		public float CameraX()
		{
			return SplashKit.CameraX();
		}

		public float CameraY()
		{
			return SplashKit.CameraY();
		}

		public SharedLibary.Point2D CameraPostion()
		{
			return new SharedLibary.Point2D(CameraX(), CameraY());
		}

		public void ProcessEvents()
		{
			SplashKit.ProcessEvents();
		}

		public void SetCamreaPostion(SharedLibary.Point2D point)
		{
			SplashKit.SetCameraPosition(PointWraper.ToSplashKit(point));
		}

		public void RefreshScreen()
		{
			SplashKit.RefreshScreen();
			SplashKit.ClearScreen();
		}

		public SharedLibary.Rectangle GetTextBounds(SharedLibary.Font font, string text)
		{
			return new SharedLibary.Rectangle
			(
				0, 0,
				SplashKit.TextWidth(text, GetSplashKitFont(font), font.Size),
				SplashKit.TextHeight(text, GetSplashKitFont(font), font.Size)
			);
		}

		private SplashKitSDK.Font GetSplashKitFont(SharedLibary.Font font)
		{
			return SplashKit.LoadFont(font.ID, font.FileLocation);
		}
	}
}
