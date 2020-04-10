using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	/// <summary>
	/// Purpose: Used to render the BoxSelect
	/// </summary>
	public class BoxSelectGraphicalComponent : GraphicsComponent
	{
		// Used to give neat Dragging effect
		private Point2D _anchor;
		private Colour _colour;
		private Rectangle _rect;
		private bool _visble;

		public BoxSelectGraphicalComponent(GameObject holder) : base(holder)
		{
			_rect = new Rectangle();
			Reset(HitBox);
			_visble = false;
			_colour = new Colour(40, 0, 255, 0);
		}

		public override bool Visible
		{
			get
			{
				return _visble;
			}
		}

		public Rectangle HitBox
		{
			get
			{
				return _rect;
			}
		}

		/// <summary>
		/// Purpose: Switches from the BoxSelect from being inactive to being active
		/// </summary>
		/// <param name="newAnchor"> new anchor </param>
		public void Reset(Point2D newAnchor)
		{
			_anchor = newAnchor;
			_rect.X = newAnchor.X;
			_rect.Y = newAnchor.Y;

			_visble = !_visble;

			if(!_visble)
			{
				_rect.X = -1;
				_rect.Y = -1;
				_rect.Width = 0;
				_rect.Height = 0;
			}
		}

		/// <summary>
		/// Purpose: uses the mousePostion to change it's size
		/// </summary>
		/// <param name="mousePostion"></param>
		public void UpdatePostion(Point2D mousePostion)
		{
			_rect.X = Math.Min(mousePostion.X, _anchor.X);
			_rect.Y = Math.Min(mousePostion.Y, _anchor.Y);
			_rect.Width = Math.Abs(_anchor.X - mousePostion.X);
			_rect.Height = Math.Abs(_anchor.Y - mousePostion.Y);
		}

		public override void Render()
		{
			if (Visible)
			{
				RenderAdapter.FillRectangle(_colour, _rect);
				// Gives it a nice OutLine
				RenderAdapter.DrawRectangle(Colour.Black, _rect);
			}
		}
	}
}
