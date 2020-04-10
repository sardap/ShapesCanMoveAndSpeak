using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibary
{
	public class Triangle : Shape
	{
		private double _size;

		public static Point2D FindCenter(Point2D top, Point2D botLeft, Point2D botRight)
		{
			return new Point2D((top.X + botLeft.X + botRight.X) / 3, (top.Y + botLeft.Y + botRight.Y) / 3);
		}

		public Triangle(Point2D top, Point2D botLeft, Point2D botRight) :  base(FindCenter(top, botLeft, botRight))
		{
			Top = top;
			BotLeft = botLeft;
			BotRight = botRight;
		}

		public Triangle(double x1, double y1, double x2, double y2, double x3, double y3) :  this(new Point2D(x1, y1), new Point2D(x2, y2), new Point2D(x3, y3))
		{
		}


		public Triangle(Point2D center, double size) : this(center, center, center)
		{
			Size = size;
		}

		public Triangle(Point2D center) : this(center, 0)
		{
		}

		public Triangle() : this(new Point2D(0, 0), 0)
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

		/// <summary>
		/// Get: Changes Size
		/// Set: Sets size then recalculates Top, BotLeft, BotRight
		/// </summary>
		public override double Size
		{
			get
			{
				return _size;
			}
			set
			{
				_size = value;
				CalcuateSize();
			}
		}

		public Point2D Top
		{
			get;
			set;
		}

		public Point2D BotLeft
		{
			get;
			set;
		}
		public Point2D BotRight
		{
			get;
			set;
		}

		public override Rectangle HitBox
		{
			get
			{
				return new Rectangle(BotLeft.X, Top.Y, BotRight.X - BotLeft.X, BotRight.Y - Top.Y);
			}
		}

		public override Shape ToBounds(Rectangle fromBounds, Rectangle toBounds)
		{
			return new Triangle
			(
				Top.TranslatePoint(fromBounds, toBounds),
				BotLeft.TranslatePoint(fromBounds, toBounds),
				BotRight.TranslatePoint(fromBounds, toBounds)
			);
		}

		public override Shape Copy()
		{
			return new Triangle(Top, BotLeft, BotRight);
		}

		private void CalcuateSize()
		{
			Top = new Point2D(X, Y - _size);

			BotLeft = new Point2D(X - _size, Y + _size);

			BotRight = new Point2D(X + _size, Y + _size);
		}

	}
}
