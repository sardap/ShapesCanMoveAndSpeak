using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibary
{
	/// <summary>
	/// Purpose: Rectangle that has a Breathing Method 
	/// To give it a breathing effect
	/// </summary>
	public class BreathingRectangle : Rectangle
	{
		private int _change = 1;
		
		public BreathingRectangle(double x, double y, double width, double height) : base(x, y, width, height)
		{
		}

		public BreathingRectangle(Point2D point, double wdith, double hieght) : this(point.X, point.Y, wdith, hieght)
		{
		}

		public BreathingRectangle(Rectangle rect) : this(rect.Point, rect.Width, rect.Height)
		{
		}

		public BreathingRectangle() : this(0, 0, 0, 0)
		{
		}


		// CREATED BY: Jacques Van Niekerk
		// AKA : THE ROVER MASTER OF THE EAST
		// AKA : MR COOL JEANS
		// AKA : MR ELLIPSE
		
		public void Alternate()
		{
			double max = Width;
			double min = Height;
			if (Height >= max || Width >= max || Height <= min || Width <= min)
			{
				_change = -1 * _change;
			}

			X = X + _change;
			Width = Width - 2 * _change;
			Y = Y - _change;
			Height = Height + 2 * _change;
		}
		 
		public void AlternateV2()
		{
			Point2D OriginalCenter = Center;
			Height = Height + _change;
			Width = Width - _change;
			Center = OriginalCenter;
			double max = Width + Height;
			double min = 2;
			if (Height >= max || Width >= max || Height <= min || Width <= min)
			{
				_change = -1 * _change;
			}
		}
		
		// END OF Jacques Van Niekerk CODE
	}
}
