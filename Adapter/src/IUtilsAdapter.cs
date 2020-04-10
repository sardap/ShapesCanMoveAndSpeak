using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Adapter
{
	public interface IUtilsAdapter
	{
		bool WindowCloseRequested
		{
			get;
		}

		void OpenGraphicsWindow(string title, int width, int height);

		float ToWorldX(float x);

		float ToWorldY(float y);

		Point2D ToWorld(Point2D point);

		int ScreenWidth();

		int ScreenHeight();

		float CameraX();

		float CameraY();

		Point2D CameraPostion();

		void ProcessEvents();

		void SetCamreaPostion(Point2D point);

		void RefreshScreen();

		Rectangle GetTextBounds(Font font, string text);
	}
}
