using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	public class MoneyFavouredBeliefComponent : BeliverBeliefComponent
	{
		private const uint LATE_AGE = 100;
		
		private static Random _rnd = new Random();
		private int _size;

		public MoneyFavouredBeliefComponent(string name, GameObject holder) : base(name, LATE_AGE, holder)
		{
			byte[] buffer = new byte[2];
			_rnd.NextBytes(buffer);
			G = buffer[0];
			B = buffer[1];

			_size = Convert.ToByte(Age);
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
			if (other.ReadyToCompare() && other.R > Size)
			{
				this.B = other.B;

				this.G = other.G;
			}
		}

		protected override void UpdateTimeToComapre()
		{
			TimeToCompare = COMAPRE_INTERVAL - Convert.ToUInt32((Inventory.Wallet.TotalValue * 0.50));
		}

		protected override void UpdateBeleifs()
		{ 
			R = byte.MaxValue;

			if (Inventory.Wallet.TotalValue > 0 && Statistics.TotalMoneyForType(Inventory.Wallet.HolderType) > 0)
			{
				R -= Convert.ToByte((Inventory.Wallet.TotalValue / Statistics.TotalMoneyForType(Inventory.Wallet.HolderType)) * byte.MaxValue);
			}

			_size = Convert.ToInt32((Age * 0.50) + (Inventory.Wallet.TotalValue * 0.50));
		}
	}
}
