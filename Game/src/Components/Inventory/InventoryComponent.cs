using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	/// <summary>
	/// Purpose: To hold items and a wallet There are no items and only a wallet
	/// This was not the original intention
	/// </summary>
	public class InventoryComponent : Component
	{
		public InventoryComponent(string type, GameObject holder) : base(holder)
		{
			Wallet = new Wallet(type);
		}

		public InventoryComponent(string type, List<Money> _money, GameObject holder) : this(type, holder)
		{
			Wallet.Add(_money);
		}

		public Wallet Wallet
		{
			get;
			set;
		}
	}
}
