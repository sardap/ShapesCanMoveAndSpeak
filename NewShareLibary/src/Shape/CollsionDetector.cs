using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibary
{
	/// <summary>
	/// Purpose: Used to Dectect Collsions Between Shapes and Point2Ds
	/// Has Overloaded Inside and Overlapping Methods
	/// </summary>
	public static class CollsionDetector
	{
		public static bool Inside(Rectangle a, Rectangle b)
		{
			return a.X1 > b.X1 && a.Y1 > b.Y1 && a.X2 < b.X2 && a.Y2 < b.Y2;
		}

		public static bool Inside(Point2D a, Rectangle b)
		{
			return Inside(new Rectangle(a, 1, 1), b);
		}

		public static bool OverLapping(Circle circle, Rectangle rect)
		{
			double distX = Math.Abs(circle.X - rect.X - rect.Width / 2);
			double distY = Math.Abs(circle.Y - rect.Y - rect.Height / 2);

			if (distX > (rect.Width / 2 + circle.Radius))
			{
				return false;
			}

			if (distY > (rect.Height / 2 + circle.Radius))
			{
				return false;
			}

			if (distX <= (rect.Width / 2))
			{
				return true;
			}

			if (distY <= (rect.Height / 2))
			{
				return true;
			}

			double dx = distX - rect.Width / 2;
			double dy = distY - rect.Height / 2;
			return (dx * dx + dy * dy <= (circle.Radius * circle.Radius));
		}

		public static bool OverLapping(Rectangle a, Circle b)
		{
			return OverLapping(b, a);
		}

		public static bool OverLapping(Rectangle a, Rectangle b)
		{
			bool partA = a.X1 < b.X2;
			bool partB = a.X2 > b.X1;
			bool partC = a.Y1 < b.Y2;
			bool partD = a.Y2 > b.Y1;

			return partA && partB && partC && partD;
		}

		/// <summary>
		/// Two Points Are Overlapping uses a Eh close enough system
		/// </summary>
		/// <param name="a">Point A</param>
		/// <param name="b">Point B</param>
		/// <returns></returns>
		public static bool OverLapping(Point2D a, Point2D b)
		{
			const double DiffBounds = 10f;

			double xDiffrence = a.X - b.X;
			double yDiffrence = a.Y - b.Y;

			bool partA = xDiffrence >= DiffBounds * -1;
			bool partD = xDiffrence <= DiffBounds;
			bool partB = yDiffrence >= DiffBounds * -1;
			bool partC = yDiffrence <= DiffBounds;


			return partA && partB && partC && partD;
		}
	}
}
