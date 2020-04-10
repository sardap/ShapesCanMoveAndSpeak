using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	public class PanelGraphicalompment : GraphicsComponent
	{
		private Shape _shape;

		public PanelGraphicalompment(Shape shape, GameObject holder) : base(holder)
		{
			_shape = shape ?? throw new NullReferenceException(); 
		}

		public Rectangle Bounds
		{
			get
			{
				return _shape.HitBox;
			}
		}

		public override bool Visible
		{
			get
			{
				return true;
			}
		}

		public override void Render()
		{
			RenderAdapter.Fill(Colour.WhiteSmoke, Utils.ToScreen(_shape));
			RenderAdapter.DrawRectangle(Colour.Black, Utils.ToScreen(_shape.HitBox));
		}
	}
}
