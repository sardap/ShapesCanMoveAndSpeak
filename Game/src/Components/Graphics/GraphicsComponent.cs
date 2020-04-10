using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;
using Adapter;

namespace Game.src
{
	/// <summary>
	/// Purpose: Used to render things
	/// </summary>
	public abstract class GraphicsComponent : Component
	{
		// This must be set by the game adapter or nothing can render
		private static RenderAdapter _renderAdapter;

		// Ensures that only GraphicsComponent can Render
		protected static RenderAdapter RenderAdapter
		{
			get
			{
				return _renderAdapter;
			}
		}

		public static void SetAdapter(RenderAdapter adapter)
		{
			_renderAdapter = adapter ?? throw new NullReferenceException();
		}

		public GraphicsComponent(GameObject holder) : base(holder)
		{
		}

		// @Bad This seems dumb ether move this and render then make an abstract render? but have it check
		// if visible 
		public abstract bool Visible
		{
			get;
		}

		public abstract void Render();
	}
}
