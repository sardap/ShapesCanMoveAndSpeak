using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.src
{
	public class MineDeleteComponet : DeleteComponet
	{
		public MineDeleteComponet(GameObject holder) : base(holder)
		{
		}

		protected override bool CheckToDelete()
		{
			return Holder.GetComponent<InventoryComponent>().Wallet.TotalValue <= 10;
		}
	}
}
