using System;
using SharedLibary;

namespace Adapter
{
    public abstract class RenderAdapter
	{
		private static RenderAdapter _singleton = null;

		public RenderAdapter()
		{
			if(_singleton != null)
			{
				throw new Exception("Cannot create more than one Render Adapter");
			}

			_singleton = this;
		}

		public abstract void DrawPixel(Colour color, Point2D point);

		public abstract void FillRectangle(Colour color, Rectangle rect);

		public abstract void FillTriangle(Colour color, Triangle tri);

		public abstract void FillCircle(Colour color, Circle circle);

		public abstract void FillEllipse(Colour color, Rectangle rect);

		public abstract void FillHexagon(Colour color, Hexagon hexagaon);

		public abstract void DrawRectangle(Colour color, Rectangle rect);

		public abstract void DrawText(Colour color, Point2D pt, Font font, string text);

		/// <summary>
		/// Uses Questionable means but achieved a level of a
		/// abstraction i am very happy with 
		/// </summary>
		/// <param name="colour"> Guess </param>
		/// <param name="shape"> Colour </param>
		public void Fill(Colour colour, Shape shape)
		{
			if(shape is Rectangle)
			{
				FillRectangle(colour, shape as Rectangle);
				return;
			}
			else if(shape is Triangle)
			{
				FillTriangle(colour, shape as Triangle);
				return;

			}
			else if(shape is Circle)
			{
				FillCircle(colour, shape as Circle);
				return;

			}
			else if (shape is Hexagon)
			{
				FillHexagon(colour, shape as Hexagon);
				return;
			}

			throw new NotImplementedException();
		}
	}
}
