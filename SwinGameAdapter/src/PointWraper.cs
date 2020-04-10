using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adapter;
using SharedLibary;

namespace SwinGameAdapter
{
	/// <summary>
	/// Purpose: Used to Wrap Swingame Points into My Points
	/// Which means it casts them as floats
	/// </summary>
	static class PointWraper
	{
		public static SwinGameSDK.Point2D ToPoint2D(Point2D point)
		{
			return new SwinGameSDK.Point2D { X = (float)point.X, Y = (float)point.Y };
		}

		public static Point2D FromPoint2D(SwinGameSDK.Point2D point)
		{
			return new Point2D(point.X, point.Y);
		}

		public static SwinGameSDK.Rectangle ToRectangle(Rectangle rect)
		{
			return new SwinGameSDK.Rectangle { X = (float)rect.X, Y = (float)rect.Y, Width = (float)rect.Width, Height = (float)rect.Height };
		}
	}
}
