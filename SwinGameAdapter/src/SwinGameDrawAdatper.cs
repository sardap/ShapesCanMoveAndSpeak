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
	public class SwinGameDrawAdatper : RenderAdapter
	{
		public SwinGameDrawAdatper()
		{
		}

		public override void DrawPixel(SharedLibary.Colour color, SharedLibary.Point2D point)
		{
			SwinGame.DrawPixel(ToSwinGameColor(color), PointWraper.ToPoint2D(point));
		}

		public override void FillRectangle(SharedLibary.Colour color, SharedLibary.Rectangle rect)
		{
			SwinGame.FillRectangle(ToSwinGameColor(color), (float)rect.X, (float)rect.Y, (float)rect.Width, (float)rect.Height);
		}

		public override void DrawRectangle(SharedLibary.Colour color, SharedLibary.Rectangle rect)
		{
			SwinGame.DrawRectangle(ToSwinGameColor(color), (float)rect.X, (float)rect.Y, (float)rect.Width, (float)rect.Height);
		}

		public override void FillTriangle(SharedLibary.Colour color, SharedLibary.Triangle tri)
		{
			SwinGame.FillTriangle(ToSwinGameColor(color), (float)tri.Top.X, (float)tri.Top.Y, (float)tri.BotLeft.X, (float)tri.BotLeft.Y, (float)tri.BotRight.X, (float)tri.BotRight.Y);
		}

		public override void FillCircle(SharedLibary.Colour color, SharedLibary.Circle circle)
		{
			SwinGame.FillCircle(ToSwinGameColor(color), (float)circle.X, (float)circle.Y, (float)circle.Radius);
		}

		public override void FillEllipse(SharedLibary.Colour color, SharedLibary.Rectangle rect)
		{
			SwinGame.FillEllipse(ToSwinGameColor(color), PointWraper.ToRectangle(rect));
		}

		public override void FillHexagon(SharedLibary.Colour color, Hexagon hexagaon)
		{
			hexagaon.Triangles.ForEach(i => FillTriangle(color, i));
		}

		public override void DrawText(SharedLibary.Colour color, SharedLibary.Point2D point, SharedLibary.Font font, string text)
		{
			SwinGame.DrawText(text, ToSwinGameColor(color), GetSwinGameFont(font), (float)point.X, (float)point.Y);
		}

		private SwinGameSDK.Color ToSwinGameColor(SharedLibary.Colour color)
		{
			return SwinGameSDK.Color.FromArgb(color.ARGB);
		}

		private SwinGameSDK.Font GetSwinGameFont(SharedLibary.Font font)
		{
			return SwinGameSDK.SwinGame.LoadFontNamed(font.ID, font.FileLocation, font.Size);
		}
	}
}
