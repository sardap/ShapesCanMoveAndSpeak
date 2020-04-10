using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using PrimitiveBuddy;
using SharedLibary;
using Adapter;

namespace MonoGameAdatper
{
	public class MonoGameDrawAdapter : RenderAdapter
	{
		public override void DrawPixel(SharedLibary.Colour color, Point2D point)
		{
			throw new NotImplementedException();
		}

		public override void FillRectangle(SharedLibary.Colour color, SharedLibary.Rectangle rect)
		{
			throw new NotImplementedException();
		}

		public override void DrawRectangle(SharedLibary.Colour color, SharedLibary.Rectangle rect)
		{
			throw new NotImplementedException();
		}

		public override void FillTriangle(SharedLibary.Colour color, Triangle tri)
		{
			throw new NotImplementedException();
		}

		public override void FillCircle(SharedLibary.Colour color, Circle circle)
		{
			throw new NotImplementedException();
		}		

		public override void FillEllipse(SharedLibary.Colour color, SharedLibary.Rectangle rect)
		{
			throw new NotImplementedException();
		}

		public override void FillHexagon(SharedLibary.Colour color, Hexagon hexagaon)
		{
			throw new NotImplementedException();
		}

		public override void DrawText(SharedLibary.Colour color, Point2D pt, Font font, string text)
		{
			throw new NotImplementedException();
		}
	}
}
