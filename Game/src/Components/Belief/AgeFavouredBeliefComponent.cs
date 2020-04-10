using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	/// <summary>
	/// Purpose: Used for believers that favour age over all else
	/// </summary>
	class AgeFavouredBeliefComponent : BeliverBeliefComponent
	{
		private const uint LATE_AGE = 100;

		private int _size;

		public AgeFavouredBeliefComponent(string name, GameObject holder) : base(name, LATE_AGE, holder)
		{
			R = (byte)Utils.Random(byte.MinValue, byte.MaxValue);
			B = (byte)Utils.Random(byte.MinValue, byte.MaxValue);
			_size = Convert.ToByte(Age);

			UpdateTimeToComapre();
		}

		public override int Size
		{
			get
			{
				return _size;
			}
		}

		public override void Compare(BeliefComponent other)
		{
			if (other.ReadyToCompare() && other.A > A)
			{
				this.R = other.R;

				this.G = other.G;
			}
		}

		protected override void UpdateTimeToComapre()
		{
			TimeToCompare = COMAPRE_INTERVAL - (Age);
		}

		protected override void UpdateBeleifs()
		{
			G = byte.MaxValue;

			if (Inventory.Wallet.TotalValue > 0 && Statistics.TotalMoneyForType(Inventory.Wallet.HolderType) > 0)
			{
				G -= Math.Max
				(
					Convert.ToByte((Inventory.Wallet.TotalValue / Statistics.TotalMoneyForType(Inventory.Wallet.HolderType)) * byte.MaxValue), 
					Convert.ToByte(0)
				);
			}
			_size = Convert.ToInt32((Age * 1.5) + (Inventory.Wallet.TotalValue * 0.15));
		}
	}
}
