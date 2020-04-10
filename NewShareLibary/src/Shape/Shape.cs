using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibary
{
	/// <summary>
	/// Purpose: Used to Unite all "Shapes" so they can be used Interchangeable 
	/// </summary>
	public abstract class Shape : Point2D
	{
		public Shape(double x, double y) : base(x, y)
		{
		}

		public Shape(Point2D point) : this(point.X, point.Y)
		{
		}

		public abstract double Size
		{
			get;
			set;
		}

		public abstract Point2D Center
		{
			get;
			set;
		}

		public abstract Rectangle HitBox
		{
			get;
		}


		/// <summary>
		/// Translates any Shape from the box it lives in into a new box
		/// </summary>
		/// <param name="fromBounds"> Where it lives </param>
		/// <param name="toBounds"> It's new Home </param>
		/// <returns></returns>
		public abstract Shape ToBounds(Rectangle fromBounds, Rectangle toBounds);

		public abstract Shape Copy();
	}
}
