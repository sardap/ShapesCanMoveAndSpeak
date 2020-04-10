using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	/// <summary>
	/// Purpose: Used to render the graphical component
	/// </summary>
	public class MiniMapGraphicsComponent : GraphicsComponent
	{
		// uses the world to get each thing which can draw on the minimap
		private World _world;

		public MiniMapGraphicsComponent(World world, Rectangle bounds, GameObject holder) : base(holder)
		{
			Bounds = bounds ?? throw new NullReferenceException();
			_world = world ?? throw new NullReferenceException();
		}

		public override bool Visible
		{
			get
			{
				return true;
			}
		}

		public Rectangle Bounds
		{
			get;
			set;
		}

		public override void Render()
		{
			RenderMiniMap();
			RenderObjectsOnMiniMap();
			RenderCamreaOnMiniMap();
		}

		private void RenderMiniMap()
		{
			RenderAdapter.FillRectangle(Colour.WhiteSmoke, Utils.ToScreen(Bounds));
			RenderAdapter.DrawRectangle(Colour.Black, Utils.ToScreen(Bounds));
		}

		private void RenderObjectsOnMiniMap()
		{
			foreach (IRenderOnMiniMap i in _world.GetComponents<GraphicsComponent>().OfType<IRenderOnMiniMap>())
			{
				i.RenderOnMiniMap(Bounds);
			}
		}

		private void RenderCamreaOnMiniMap()
		{
			RenderAdapter.DrawRectangle
			(
				Colour.Black, 
				Utils.ToScreen(Utils.CameraPostionRectangle().ToBounds(Settings.Instance.Gamebounds, Bounds) as Rectangle)
			);
		}
	}
}
