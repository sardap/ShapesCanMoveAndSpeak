using System;
using System.Collections.Generic;
using System.IO;
using SharedLibary;
using Adapter;

namespace Game.src
{
	public static class Utils
	{
		private static IUtilsAdapter _utilsAdapter = null;

		private static Random _rnd = new Random();

		// <DANGER ZONE>

		public static bool WindowCloseRequested
		{
			get
			{
				return _utilsAdapter.WindowCloseRequested;
			}
		}

		public static void SetAdapter(IUtilsAdapter adapter)
		{
			_utilsAdapter = adapter ?? throw new NullReferenceException();
		}

		public static void OpenGraphicsWindow()
		{
			_utilsAdapter.OpenGraphicsWindow(Settings.Instance.WindowTitle, Settings.Instance.ScreenWidth, Settings.Instance.ScreenHeight);
		}

		public static int ScreenHeight()
		{
			return _utilsAdapter.ScreenHeight();
		}

		public static int ScreenWidth()
		{
			return _utilsAdapter.ScreenWidth();
		}

		public static void SetCamreaPostion(Point2D postion)
		{
			_utilsAdapter.SetCamreaPostion(postion);
		}

		public static void ProcessEvents()
		{
			_utilsAdapter.ProcessEvents();
		}

		public static void RefreshScreen()
		{
			_utilsAdapter.RefreshScreen();
		}

		public static Point2D CameraPostion()
		{
			return _utilsAdapter.CameraPostion();
		}

		public static Rectangle GetTextBounds(Font font, string text)
		{
			Rectangle result = _utilsAdapter.GetTextBounds(font, text);
			return result;
		}

		// </DANGER ZONE>

		public static byte SafeByteCast(int x)
		{
			if(x > byte.MaxValue)
			{
				return byte.MaxValue;
			}
			else if(x < byte.MinValue)
			{
				return byte.MinValue;
			}

			return Convert.ToByte(x);
		}


		public static void SetCamreaCenter(Point2D pt)
		{
			SetCamreaPostion(new Point2D(pt.X - (ScreenWidth() / 2), pt.Y - (ScreenHeight() / 2)));
		}

		public static int Random(int min, int max)
		{
			return _rnd.Next(min, max);
		}

		public static bool InsideGameBounds(Point2D pt)
		{
			return CollsionDetector.Inside(pt, Settings.Instance.Gamebounds);
		}

		public static bool InsideGameBounds(Rectangle rect)
		{
			return CollsionDetector.Inside(rect, Settings.Instance.Gamebounds);
		}

		public static Rectangle CameraPostionRectangle()
		{
			return new Rectangle(_utilsAdapter.CameraPostion(), _utilsAdapter.ScreenWidth(), _utilsAdapter.ScreenHeight());
		}

		public static Point2D RandomScreenPoint()
		{
			return CameraPostionRectangle().RandomPointInside();
		}

		public static Point2D RandomWorldPoint()
		{
			return Settings.Instance.Gamebounds.RandomPointInside();
		}

		public static double TranslatePoint(double x, double fromBound, double boundX, double toBound)
		{
			return toBound / (fromBound / x) + boundX;
		}

		public static Point2D FromBoundsToWorld(Point2D location, Rectangle bounds)
		{
			return new Point2D
			(
				TranslatePoint(location.X - bounds.X, bounds.Width, Settings.Instance.Gamebounds.X, Settings.Instance.Gamebounds.Width),
				TranslatePoint(location.Y - bounds.Y, bounds.Height, Settings.Instance.Gamebounds.Y, Settings.Instance.Gamebounds.Height)
			);
		}

		public static Point2D ToWorld(Point2D pt)
		{
			return _utilsAdapter.ToWorld(pt);
		}


		public static double ToScreenX(double x)
		{
			return x + _utilsAdapter.CameraX();
		}

		public static double ToScreenY(double y)
		{
			return y + _utilsAdapter.CameraY();
		}

		public static Point2D ToScreen(Point2D point)
		{
			return new Point2D(ToScreenX(point.X), ToScreenY(point.Y));
		}

		public static Rectangle ToScreen(Rectangle rect)
		{
			return new Rectangle(ToScreen(rect.Point), rect.Width, rect.Height);
		}

		public static Circle ToScreen(Circle circle)
		{
			return new Circle(ToScreen(circle.Point), circle.Radius);
		}

		public static Triangle ToScreen(Triangle tri)
		{
			return new Triangle(ToScreen(tri.Top), ToScreen(tri.BotLeft), ToScreen(tri.BotRight));
		}

		public static Hexagon ToScreen(Hexagon hexagon)
		{
			return new Hexagon(ToScreen(hexagon.HitBox));
		}

		public static Shape ToScreen(Shape shape)
		{
			if (shape is Rectangle)
			{
				return ToScreen(shape as Rectangle);
			}
			else if (shape is Triangle)
			{
				return ToScreen(shape as Triangle);
			}
			else if(shape is Circle)
			{
				return ToScreen(shape as Circle);
			}
			else if (shape is Hexagon)
			{
				return ToScreen(shape as Hexagon);
			}

			throw new NotImplementedException();
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="baseFileName">Should be the first in a numbered sequnce Example CoolFarts then the first file is CoolFarts1</param>
		/// <returns></returns>
		public static List<string> GetFileSequnce(string baseFileName)
		{
			List<string> fileNames = new List<string>();

			try
			{
				int i = 1;
				string fileName = MakeFileNameFromBase(baseFileName, i);

				while (File.Exists(fileName))
				{
					fileNames.Add(fileName);
					i++;
					fileName = MakeFileNameFromBase(baseFileName, i);
				}

			}
			catch(FileNotFoundException e)
			{
				System.Diagnostics.Debug.WriteLine(e);
			}

			return fileNames;
		}

		private static string MakeFileNameFromBase(string baseFileName, int i)
		{
			return baseFileName.Split('.')[0] + i + '.' + baseFileName.Split('.')[1];
		}
	}
}