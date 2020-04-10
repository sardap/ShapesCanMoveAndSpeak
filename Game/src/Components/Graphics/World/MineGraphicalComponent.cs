using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using SharedLibary;

namespace Game.src
{
	/// <summary>
	/// Purpose: Used to render mines
	/// </summary>
	public class MineGraphicalComponent : WorldGraphicsComponent, IRenderOnMiniMap, IHavePortrait
	{
		private Colour _miniMapColour = Colour.Gold;
		private InventoryComponent _inventory;
		// Starting money When created
		private int _startingMoney;
		private Rectangle _rect;

		public MineGraphicalComponent(Rectangle rect, GameObject holder) : base(holder)
		{
			_inventory = holder.GetComponent<InventoryComponent>() ?? throw new NullReferenceException();
			_rect = rect ?? throw new NullReferenceException();

			_startingMoney = _inventory.Wallet.TotalValue;

			Colour = Colour.DarkGray;
		}

		public override Point2D Center
		{
			get
			{
				return _rect.Center;
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public void RenderPortrait(Rectangle bounds)
		{
			RenderAdapter.Fill
			(
				_miniMapColour,
				new Rectangle(bounds.Center.X - (bounds.Width / 2) / 2, bounds.Y, bounds.Width / 2, bounds.Height - 2)
			);
		}

		public string Title
		{
			get
			{
				return "Mr Mine";
			}
		}

		public override bool Visible
		{
			get
			{
				return CollsionDetector.OverLapping(_rect, Utils.CameraPostionRectangle());
			}
		}

		public override void Update(long deltaTime)
		{
			if (_inventory.Wallet.TotalValue != 0)
			{
				// A is the percentage of gold left in ht mine from when it was created
				Colour.A = (Convert.ToByte((Convert.ToDouble(_inventory.Wallet.TotalValue) / Convert.ToDouble(_startingMoney)) * byte.MaxValue));
				_miniMapColour.A = Colour.A;
			}
		}

		public virtual void RenderOnMiniMap(Rectangle bounds)
		{
			RenderAdapter.FillRectangle
			(
				_miniMapColour, Utils.ToScreen(_rect.ToBounds(Settings.Instance.Gamebounds, bounds) as Rectangle)
			);
		}

		public override void Render()
		{
			if (Visible)
			{
				RenderAdapter.FillRectangle(Colour, _rect);
			}

			if (Settings.DEBUG)
			{
				RenderAdapter.DrawRectangle(Colour.Red, _rect);
			}
		}
	}
}