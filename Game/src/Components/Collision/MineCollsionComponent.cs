using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	public class MineCollsionComponent : CollsionComponent
	{
		private Rectangle _bounds;
		private InventoryComponent _inventory;

		public MineCollsionComponent(Rectangle bounds, GameObject holder) : base(holder)
		{
			_inventory = Holder.GetComponent<InventoryComponent>() ?? throw new NullReferenceException();
			_bounds = bounds ?? throw new NullReferenceException();

		}

		public override Rectangle Bounds
		{
			get
			{
				return _bounds;
			}
		}

		protected override void CollsionAction()
		{
			foreach (BeliverCollisionComponent i in ColliedObjects.OfType<BeliverCollisionComponent>())
			{
				if (i.ReadyToMine())
				{
					_inventory.Wallet.Transfer(i.Holder.GetComponent<InventoryComponent>().Wallet, Utils.Random(0, 10));
				}
			}
		}
	}
}
