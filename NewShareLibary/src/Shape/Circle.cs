using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibary
{
	public class Circle : Shape
	{
		public Circle(double x, double y, double radius) : base(x, y)
		{
			Radius = radius;
		}

		public Circle(Point2D point, double radius) : this(point.X, point.Y, radius)
		{
		}

		public Circle() : this(0, 0, 0)
		{
		}

		public override Point2D Center
		{
			get
			{
				return Point;
			}
			set
			{
				Point = value;
			}
		}
		
		public override double Size
		{
			get;
			set;
		}

		/// <summary>
		/// Purpose: Circles should have a radius but 
		/// it is just an altantve name for size
		/// </summary>
		public double Radius
		{
			get
			{
				return Size;
			}
			set
			{
				Size = value;
			}
		}

		public override Shape ToBounds(Rectangle fromBounds, Rectangle toBounds)
		{
			Rectangle boundBox = HitBox.ToBounds(fromBounds, toBounds) as Rectangle;

			return boundBox.CircleInCenter();
		}

		public override Rectangle HitBox
		{
			get
			{
				return new Rectangle(X - Radius, Y - Radius, Radius * 2, Radius * 2);
			}
		}

		public override Shape Copy()
		{
			return new Circle(X, Y, Radius);
		}
	}
}