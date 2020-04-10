using System;
using System.Collections.Generic;
using System.Text;
using SharedLibary;
using Adapter;

namespace SplashKitAdapter
{
	public class SplashKitDrawAdapter : RenderAdapter
	{
		public SplashKitDrawAdapter()
		{
		}

		public override void DrawPixel(Colour color, Point2D point)
		{
			SplashKitSDK.SplashKit.DrawPixel(ToSplashKitColor(color), point.X, point.Y);
		}

		public override void FillRectangle(Colour color, Rectangle rect)
		{
			SplashKitSDK.SplashKit.FillRectangle(ToSplashKitColor(color), rect.X, rect.Y, rect.Width, rect.Height);
		}

		public override void DrawRectangle(Colour color, Rectangle rect)
		{
			SplashKitSDK.SplashKit.DrawRectangle(ToSplashKitColor(color), rect.X, rect.Y, rect.Width, rect.Height);
		}

		public override void FillTriangle(Colour color, Triangle tri)
		{
			SplashKitSDK.SplashKit.FillTriangle(ToSplashKitColor(color), tri.Top.X, tri.Top.Y, tri.BotLeft.X, tri.BotLeft.Y, tri.BotRight.X, tri.BotRight.Y);
		}

		public override void FillCircle(Colour color, Circle circle)
		{
			SplashKitSDK.SplashKit.FillCircle(ToSplashKitColor(color), circle.X, circle.Y, circle.Radius);
		}

		public override void FillEllipse(Colour color, Rectangle rect)
		{
			SplashKitSDK.SplashKit.FillEllipse(ToSplashKitColor(color), rect.X, rect.Y, rect.Width, rect.Height);
		}

		public override void FillHexagon(Colour color, Hexagon hexagaon)
		{
			hexagaon.Triangles.ForEach(i => FillTriangle(color, i));
		}

		public override void DrawText(Colour color, Point2D pt, Font font, string text)
		{
			SplashKitSDK.SplashKit.DrawText(text, ToSplashKitColor(color), font.ID, font.Size, pt.X, pt.Y);
		}

		private SplashKitSDK.Color ToSplashKitColor(Colour color)
		{
			return SplashKitSDK.SplashKit.RGBAColor(color.R, color.G, color.B, color.A);
		}
	}
}
