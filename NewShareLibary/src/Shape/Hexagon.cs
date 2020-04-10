using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibary
{
	public class Hexagon : Shape
	{
		/// <summary>
		/// Purpose: uses 6 triangles refer here http://1.bp.blogspot.com/_ZP4soQHEeiE/S8XZJ6J6MGI/AAAAAAAABNc/7mh7YC0wiN8/s400/hexagon.png
		/// Store them in an array
		/// </summary>
		private Triangle[] _triangles = new Triangle[6];
		private double _size;

		public Hexagon(double x, double y, double size) : base(x, y)
		{
			_size = size;
			CreateTriangles();
		}

		public Hexagon(Point2D center, double size) : this(center.X, center.Y, size)
		{
		}

		public Hexagon(Shape shape) : this(shape.Center, shape.Size)
		{
		}

		public Hexagon() : this(0, 0, 0)
		{
		}

		/// <summary>
		/// Get: returns Point
		/// Set: Sets Point then Recalcuates Triangle Postions
		/// </summary>
		public override Point2D Center
		{
			get
			{
				return base.Point;
			}
			set
			{
				base.Point = value;
				CreateTriangles();
			}
		}

		/// <summary>
		/// Get: Returns Size
		/// Set: Sets Size then Recreates Triangles
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
				CreateTriangles();
			}
		}

		/// <summary>
		/// Purpose: Returns the array of triangles as a list
		/// </summary>
		public List<Triangle> Triangles
		{
			get
			{
				return _triangles.ToList();
			}
		}

		public override Rectangle HitBox
		{
			get
			{
				return new Rectangle(Point, _size);
			}
		}

		public override Shape ToBounds(Rectangle fromBounds, Rectangle toBounds)
		{
			Rectangle transaltedHitBox = HitBox.ToBounds(fromBounds, toBounds) as Rectangle;

			return transaltedHitBox.HexagonInCenter();
		}

		public override Shape Copy()
		{
			return new Hexagon(X, Y, Size);
		}

		private void CreateTriangles()
		{
			// /\
			_triangles[0] = new Triangle(new Point2D(X - _size / 4, Y - _size / 2), new Point2D(X - _size / 2, Y), new Point2D(X, Y));
			// \/
			_triangles[1] = new Triangle(new Point2D(X, Y), new Point2D(X - _size / 4, Y - _size / 2), new Point2D(X + _size / 4, Y - _size / 2));
			// /\
			_triangles[2] = new Triangle(new Point2D(X + _size / 4, Y - _size / 2), new Point2D(X, Y), new Point2D(X + _size / 2, Y));
			// \/
			_triangles[3] = new Triangle(new Point2D(X, Y), new Point2D(X + _size / 2, Y), new Point2D(X + _size / 4, Y + _size / 2));
			// /\
			_triangles[4] = new Triangle(new Point2D(X, Y), new Point2D(X + _size / 4, Y + _size / 2), new Point2D(X - _size / 4, Y + _size / 2));
			// \/
			_triangles[5] = new Triangle(new Point2D(X - _size / 2, Y), new Point2D(X - _size / 4, Y + _size / 2), new Point2D(X, Y));
		}
	}
}
