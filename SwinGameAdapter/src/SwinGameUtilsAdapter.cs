using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;
using SharedLibary;
using Adapter;

namespace SwinGameAdapter
{
	public class SwinGameUtilsAdapter : IUtilsAdapter
	{
		public SwinGameUtilsAdapter()
		{
		}

		public bool WindowCloseRequested
		{
			get
			{
				return SwinGame.WindowCloseRequested();
			}
		}

		public void OpenGraphicsWindow(string title, int width, int height)
		{
			SwinGame.OpenGraphicsWindow(title, width, height);
		}


		public float ToWorldX(float x)
		{
			return SwinGame.ToWorldX(x);
		}

		public float ToWorldY(float y)
		{
			return SwinGame.ToWorldY(y);
		}

		public SharedLibary.Point2D ToWorld(SharedLibary.Point2D point)
		{
			return PointWraper.FromPoint2D(SwinGameSDK.SwinGame.ToWorld(PointWraper.ToPoint2D(point)));
		}

		public int ScreenWidth()
		{
			return SwinGame.ScreenWidth();
		}

		public int ScreenHeight()
		{
			return SwinGame.ScreenHeight();
		}

		public float CameraX()
		{
			return SwinGame.CameraX();
		}

		public float CameraY()
		{
			return SwinGame.CameraY();
		}

		public SharedLibary.Point2D CameraPostion()
		{
			return new SharedLibary.Point2D(CameraX(), CameraY());
		}

		public void ProcessEvents()
		{
			SwinGame.ProcessEvents();
		}

		public void SetCamreaPostion(SharedLibary.Point2D point)
		{
			SwinGame.SetCameraX((float)point.X);
			SwinGame.SetCameraY((float)point.Y);
		}

		public void RefreshScreen()
		{
			SwinGame.RefreshScreen();
			SwinGame.ClearScreen();
		}

		public SharedLibary.Rectangle GetTextBounds(SharedLibary.Font font, string text)
		{
			return new SharedLibary.Rectangle
			(
				0, 0, 
				SwinGame.TextWidth(GetSwinGameFont(font), text), 
				SwinGame.TextHeight(GetSwinGameFont(font), text)
			);
		}

		private SwinGameSDK.Font GetSwinGameFont(SharedLibary.Font font)
		{
			return SwinGameSDK.SwinGame.LoadFontNamed(font.ID, font.FileLocation, font.Size);
		}
	}
}
