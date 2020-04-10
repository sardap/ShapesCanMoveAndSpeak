using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	public class BelieverGraphicalComponent : WorldGraphicsComponent, IRenderOnMiniMap, IHaveInfo, IHavePortrait
	{
		private const string FONT_NAME = "standard";

		private Shape _shape;
		private BeliverBeliefComponent _belief;

		public BelieverGraphicalComponent(Shape shape, GameObject holder) : base(holder)
		{
			if (Move == null)
			{
				throw new NullReferenceException();
			}

			_shape = shape ?? throw new NullReferenceException();
			_belief = Holder.GetComponent<BeliverBeliefComponent>() ?? throw new NullReferenceException();
		}

		public override bool Visible
		{
			get
			{
				return CollsionDetector.OverLapping(Bounds, Utils.CameraPostionRectangle());
			}
		}

		public Rectangle Bounds
		{
			get
			{
				return _shape.HitBox;
			}
		}

		public override Point2D Center
		{
			get
			{
				return _shape.Center;
			}
			set
			{
				_shape.Center = value;
			}
		}

		public string Title
		{
			get
			{
				return _belief.Name;
			}
		}

		public override void Update(long deltaTime)
		{
			Move.Move(this, deltaTime);
			Colour = _belief.Color;
			_shape.Size = _belief.Size;
		}

		public void RenderOnMiniMap(Rectangle bounds)
		{
			RenderAdapter.Fill(Colour, Utils.ToScreen(_shape.ToBounds(Settings.Instance.Gamebounds, bounds)));
		}

		public override void Render()
		{
			RenderAdapter.Fill(Colour, _shape);
		}

		public virtual void RenderPortrait(Rectangle bounds)
		{
			RenderAdapter.Fill
			(
				new Colour(byte.MaxValue, Colour.R, Colour.G, Colour.B),
				bounds.ShapeInCenter(_shape.GetType())
			);
		}

		public void RenderInfo()
		{
			if (Visible)
			{
				RenderName();
				RenderAge();
			}
		}

		private void RenderName()
		{
			int textSize = _belief.Size / 2;

			Rectangle textBounds = Utils.GetTextBounds(ResoruceManger.GetFont(FONT_NAME, textSize), _belief.Name);

			RenderAdapter.DrawText
			(
				Colour.Black, 
				new Point2D(Bounds.Center.X - textBounds.Width / 2, Bounds.Y - textBounds.Height), 
				ResoruceManger.GetFont(FONT_NAME, textSize), _belief.Name
			);

		}

		private void RenderAge()
		{
			int textSize = _belief.Size / 2;

			Rectangle textBounds = Utils.GetTextBounds
			(
				ResoruceManger.GetFont(FONT_NAME, textSize), 
				_belief.Age.ToString()
			);

			RenderAdapter.DrawText
			(
				Colour.Black, 
				new Point2D(Center.X - textBounds.Width / 2, Center.Y - textBounds.Height / 2), 
				ResoruceManger.GetFont(FONT_NAME, textSize), 
				_belief.Age.ToString()
			);
		}
	}
}
