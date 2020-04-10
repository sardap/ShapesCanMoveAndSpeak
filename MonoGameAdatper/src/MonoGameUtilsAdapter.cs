using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adapter;
using SharedLibary;
using Microsoft.Xna.Framework;

namespace MonoGameAdatper
{
	public class MonoGameUtilsAdapter : IUtilsAdapter
	{
		public bool WindowCloseRequested
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public void OpenGraphicsWindow(string title, int width, int height)
		{
			MonoGameManger.Game.SetGraphicsWindow(width, height);
			MonoGameManger.Game.Run();
		}

		public float ToWorldX(float x)
		{
			throw new NotImplementedException();
		}

		public float ToWorldY(float y)
		{
			throw new NotImplementedException();
		}

		public Point2D ToWorld(Point2D point)
		{
			throw new NotImplementedException();
		}

		public float MouseX()
		{
			throw new NotImplementedException();
		}

		public float MouseY()
		{
			throw new NotImplementedException();
		}

		public int ScreenWidth()
		{
			throw new NotImplementedException();
		}

		public int ScreenHeight()
		{
			throw new NotImplementedException();
		}

		public float CameraX()
		{
			throw new NotImplementedException();
		}

		public float CameraY()
		{
			throw new NotImplementedException();
		}

		public Point2D CameraPostion()
		{
			throw new NotImplementedException();
		}

		public void ProcessEvents()
		{
			throw new NotImplementedException();
		}

		public void SetCamreaPostion(Point2D point)
		{
			throw new NotImplementedException();
		}

		public void RefreshScreen()
		{
			throw new NotImplementedException();
		}

		public SharedLibary.Rectangle GetTextBounds(Font font, string text)
		{
			throw new NotImplementedException();
		}
	}
}
