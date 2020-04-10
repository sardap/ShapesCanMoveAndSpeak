using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibary
{
	/// <summary>
	/// Used to store a Color as A, R, G, B
	/// </summary>
	public class Colour
	{
		public static Colour Gold
		{
			get
			{
				return new Colour(255, 255, 215, 0);
			}
		}

		public static Colour WhiteSmoke
		{
			get
			{
				return new Colour(255, 245, 245, 245);
			}
		}

		public static Colour Black
		{
			get
			{
				return new Colour(255, 0, 0, 0);
			}
		}

		public static Colour DarkGray
		{
			get
			{
				return new Colour(255, 169, 169, 169);
			}
		}

		public static Colour White
		{
			get
			{
				return new Colour(255, 255, 255, 255);
			}
		}

		public static Colour Red
		{
			get
			{
				return new Colour(255, 255, 0, 0);
			}
		}

		/// <summary>
		/// Will Convert a, r, g, b into a single int
		/// </summary>
		/// <param name="a">Alpha</param>
		/// <param name="r">Red</param>
		/// <param name="g">Green</param>
		/// <param name="b">Blue</param>
		/// <returns></returns>
		public static int ToARGB(byte a, byte r, byte g, byte b)
		{
			int color = 0;
			color |= a << 24;
			color |= r << 16;
			color |= g << 8;
			color |= b;
			return color;
		}

		/// <summary>
		/// Returns a list of bytes which repersent a, r, g, b given an intger
		/// </summary>
		/// <param name="argb">ARGB value of color</param>
		/// <returns></returns>
		public static List<byte> FromARGB(int argb)
		{
			return BitConverter.GetBytes(Convert.ToUInt32(argb)).ToList();
		}

		/// <summary>
		/// Initlises Colour with a, r, g, b
		/// </summary>
		public Colour(byte a, byte r, byte g, byte b)
		{
			A = a;
			R = r;
			G = g;
			B = b;
		}

		/// <summary>
		/// Takes argb in a list of bytes passes up the chain
		/// </summary>
		/// <param name="argb"></param>
		public Colour(List<byte> argb) : this(argb[0], argb[1], argb[2], argb[3])
		{
		}

		/// <summary>
		/// Takes a single Int that reprasent ARGB converts into a 
		/// list and passes up the chain
		/// </summary>
		/// <param name="argb"></param>
		public Colour(int argb) : this(FromARGB(argb))
		{
		}

		/// <summary>
		/// Alpha
		/// </summary>
		public byte A
		{
			get;
			set;
		}

		/// <summary>
		/// Red
		/// </summary>
		public byte R
		{
			get;
			set;
		}

		/// <summary>
		/// Green
		/// </summary>
		public byte G
		{
			get;
			set;
		}

		/// <summary>
		/// Blue
		/// </summary>
		public byte B
		{
			get;
			set;
		}

		/// <summary>
		/// Get: Returns A, R, G, B in a single Int
		/// Set: Set's A, R, G, B form a single Int
		/// </summary>
		public int ARGB
		{
			get
			{
				return ToARGB(A, R, G, B);
			}
			set
			{
				List<byte> reuslt = FromARGB(value);
				A = reuslt[0];
				R = reuslt[1];
				G = reuslt[2];
				B = reuslt[3];
			}
		}
	}
}
