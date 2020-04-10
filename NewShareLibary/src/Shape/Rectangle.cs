using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibary
{
	public class Rectangle : Shape
	{
		public Rectangle(double x, double y, double width, double height) : base(x, y)
		{
			Width = width;
			Height = height;
		}

		public Rectangle(Point2D point, double width, double hieght) : this(point.X, point.Y, width, hieght)
		{
		}

 		public Rectangle(Point2D center, double size) : this(center.X - size / 2, center.Y - size / 2, size, size)
		{
		}

		public Rectangle(Rectangle rect) : this(rect.Point, rect.Width, rect.Height)
		{
		}

		public Rectangle() : this(0, 0, 0, 0)
		{
		}

		public virtual double Width
		{
			get;
			set;
		}

		public virtual double Height
		{
			get;
			set;
		}

		/// <summary>
		/// Get: returns the min between width and height
		/// Set: Sets Both Width and Height
		/// </summary>
		public override double Size
		{
			get
			{
				return Math.Min(Width, Height);
			}
			set
			{
				Width = value;
				Height = value;
			}
		}

		/// <summary>
		/// Get: Returns Center in a new Point2D
		/// Set: Sets both X and Y to be the new center
		/// </summary>
		public override Point2D Center
		{
			get
			{
				return new Point2D((X1 + X2) / 2, (Y1 + Y2) / 2);
			}
			set
			{
				X = value.X - (Width / 2);
				Y = value.Y - (Height / 2);
			}
		}

		public override Rectangle HitBox
		{
			get
			{
				return this;
			}
		}

		public Point2D WidthAndHeight
		{
			get
			{
				return new Point2D(Width, Height);
			}
		}

		public double X1
		{
			get
			{
				return X;
			}
		}

		public double X2
		{
			get
			{
				return X + Width;
			}
		}

		public double Y1
		{
			get
			{
				return Y;
			}
		}

		public double Y2
		{
			get
			{
				return Y + Height;
			}
		}

		public override Shape ToBounds(Rectangle fromBounds, Rectangle toBounds)
		{
			return new Rectangle
			(
				Point.TranslatePoint(fromBounds, toBounds),
				Math.Max(toBounds.Width * (Width / fromBounds.Width), 1),
				Math.Max(toBounds.Height * (Height / fromBounds.Height), 1)
			);
		}

		public override Shape Copy()
		{
			return new Rectangle(X, Y, Width, Height);
		}

		public Rectangle RectangleInCenter()
		{
			return Copy() as Rectangle;
		}

		public Circle CircleInCenter()
		{
			return new Circle(Center, Math.Min(Width, Height) / 2);
		}

		public Triangle TriangleInCenter()
		{
			return new Triangle(Center, Math.Min(Width, Height) / 2.1);
		}

		public Hexagon HexagonInCenter()
		{
			return new Hexagon(Center, Math.Min(Width, Height));
		}

		public Shape ShapeInCenter(Type type)
		{
			if(type == typeof(Circle))
			{
				return CircleInCenter();
			}
			
			if(type == typeof(Triangle))
			{
				return TriangleInCenter();
			}

			if(type == typeof(Hexagon))
			{
				return HexagonInCenter();
			}

			if(type == typeof(Rectangle))
			{
				return RectangleInCenter();
			}

			throw new NotImplementedException();
		}

		public Point2D RandomPointInside()
		{
			return new Point2D
			(
				Random.Next(Convert.ToInt32(X), Convert.ToInt32(X2)) + Random.NextDouble(),
				Random.Next(Convert.ToInt32(Y), Convert.ToInt32(Y2)) + Random.NextDouble()
			);
		}
	}
}