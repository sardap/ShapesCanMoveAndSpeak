using System;
using System.Collections.Generic;
using System.Text;
using SplashKitSDK;
using SharedLibary;

namespace SplashKitAdapter
{
	/// <summary>
	/// Uses to translate my Point2D's into SplashKit Point2Ds
	/// </summary>
    public static class PointWraper
    {
		public static SplashKitSDK.Point2D ToSplashKit(SharedLibary.Point2D pt)
		{
			return new SplashKitSDK.Point2D { X = pt.X, Y = pt.Y };
		}

		public static SharedLibary.Point2D FromSplashKit(SplashKitSDK.Point2D pt)
		{
			return new SharedLibary.Point2D(pt.X, pt.Y);
		}
	}
}
