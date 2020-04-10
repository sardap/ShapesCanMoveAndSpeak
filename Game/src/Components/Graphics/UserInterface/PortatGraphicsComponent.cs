using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	public class PortatGraphicsComponent : GraphicsComponent
	{
		private IHavePortrait _subject;
		private Shape _bounds;

		public PortatGraphicsComponent(IHavePortrait subject, Shape bounds, GameObject holder) : base(holder)
		{
			_subject = subject ?? throw new NullReferenceException();
			_bounds = bounds ?? throw new NullReferenceException();
		}

		public override bool Visible
		{
			get
			{
				return true;
			}
		}

		public Point2D Postion
		{
			get
			{
				return _bounds;
			}
			set
			{
				_bounds.Point = value;
			}
		}

		public Rectangle Bounds
		{
			get
			{
				return _bounds.HitBox;
			}
		}

		public override void Render()
		{
			Rectangle boundsScreen = Utils.ToScreen(_bounds.HitBox);

			RenderAdapter.FillRectangle(Colour.White, boundsScreen);
			RenderAdapter.DrawRectangle(Colour.Black, boundsScreen);

			_subject.RenderPortrait(boundsScreen);

			RenderAdapter.DrawText
			(
				Colour.Black,
				new Point2D(boundsScreen.X, boundsScreen.Y2 - Convert.ToInt32(boundsScreen.Width / 6)),
				ResoruceManger.GetFont(Settings.DEFUALT_FONT_NAME, Convert.ToInt32(boundsScreen.Width / 6)),
				_subject.Title
			);
		}
	}
}
