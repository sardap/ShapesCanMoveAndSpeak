using System;

namespace SharedLibary
{
	/// <summary>
	/// Purpose: Used to Store X and Y postions
	/// </summary>
	public class Point2D
	{
		private static Random _rnd = new Random();

		public static Point2D Add(Point2D pt1, Point2D pt2)
		{
			return new Point2D(pt1.X + pt2.X, pt1.Y + pt2.Y);
		}

		public static Point2D Add(Point2D pt, double toAdd)
		{
			return new Point2D(pt.X + toAdd, pt.Y + toAdd);
		}

		public static Point2D Mutipy(Point2D pt1, Point2D pt2)
		{
			return new Point2D(pt1.X * pt2.X, pt1.Y * pt2.Y);
		}

		public static Point2D Subtract(Point2D pt1, Point2D pt2)
		{
			return new Point2D(pt1.X - pt2.X, pt1.Y - pt2.Y);
		}

		public static Point2D Subtract(Point2D pt1, double toSub)
		{
			return new Point2D(pt1.X - toSub, pt1.Y - toSub);
		}

		/// <summary>
		/// Purpose: Used so Derived classes can use the Random Class
		/// </summary>
		protected static Random Random
		{
			get
			{
				return _rnd;
			}
		}

		public Point2D(double x, double y)
		{
			X = x;
			Y = y;
		}

		public Point2D(Point2D point) : this(point.X, point.Y)
		{
		}

		/// <summary>
		/// Purpose: Allows for Point2D to be set with another Point2D
		/// </summary>
		public virtual Point2D Point
		{
			get
			{
				return this;
			}
			set
			{
				X = value.X;
				Y = value.Y;
			}
		}

		public double X
		{
			get;
			set;
		}

		public double Y
		{
			get;
			set;
		}

		public Point2D Mutiply(Point2D factor)
		{
			X *= factor.X;
			Y *= factor.Y;

			return this;
		}

		public Point2D Mutiply(double factor)
		{
			Mutiply(new Point2D(factor, factor));
			
			return this;
		}

		public Point2D Divide(Point2D divosr)
		{
			X /= divosr.X;
			Y /= divosr.Y;

			return this;
		}

		public Point2D Divide(double divosr)
		{
			Divide(new Point2D(divosr, divosr));

			return this;
		}

		public Point2D Add(Point2D toAdd)
		{
			X += toAdd.X;
			Y += toAdd.Y;

			return this;
		}

		public Point2D Add(double toAdd)
		{
			Add(new Point2D(toAdd, toAdd));

			return this;
		}

		public Point2D Subtract(Point2D toSub)
		{
			X -= toSub.X;
			Y -= toSub.Y;

			return this;
		}

		public Point2D Subtract(double toSub)
		{
			Subtract(new Point2D(toSub, toSub));

			return this;
		}

		/// <summary>
		/// Purpose: Translate the point form a given bounds (Where it lives) 
		/// to new bounds 
		/// </summary>
		/// <param name="fromBounds"> Current Bounds </param>
		/// <param name="toBounds"> New Bounds </param>
		/// <returns></returns>
		public Point2D TranslatePoint(Rectangle fromBounds, Rectangle toBounds)
		{
			return new Point2D
			(
				TransalteSinglePoint(X, fromBounds.Width, toBounds.X, toBounds.Width),
				TransalteSinglePoint(Y, fromBounds.Height, toBounds.Y, toBounds.Height)
			);
		}

		private double TransalteSinglePoint(double x, double fromBound, double boundX, double toBound)
		{
			return toBound / (fromBound / x) + boundX;
		}
	}
}