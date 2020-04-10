using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	/// <summary>
	/// Purpose: Provides a base class for the beleiver which stores a A, R, G, B value all
	/// represent different aspects
	/// </summary>
	public abstract class BeliefComponent : Component, IHaveUpdate
	{
		public BeliefComponent(byte a, byte r, byte g, byte b, GameObject holder) : base(holder)
		{
			Color = new Colour(a, r, g, b);
		}

		public BeliefComponent(Colour color, GameObject holder) : this(color.A, color.R, color.G, color.B, holder)
		{
		}

		public BeliefComponent(int argb, GameObject holder) : this(new Colour(argb), holder)
		{
		}

		public BeliefComponent(GameObject holder) : this(0, holder)
		{

		}

		public byte A
		{
			get
			{
				return Color.A;
			}
			set
			{
				Color.A = value;
			}
		}

		public byte R
		{
			get
			{
				return Color.R;
			}
			set
			{
				Color.R = value;
			}
		}

		public byte G
		{
			get
			{
				return Color.G;
			}
			set
			{
				Color.G = value;
			}
		}

		public byte B
		{
			get
			{
				return Color.B;
			}
			set
			{
				Color.B = value;
			}
		}

		public Colour Color
		{
			get;
			set;
		}

		public abstract int Size
		{
			get;
		}

		public abstract void Update(long deltaTime);

		public abstract bool ReadyToCompare();

		public abstract void Compare(BeliefComponent other);
	}
}
