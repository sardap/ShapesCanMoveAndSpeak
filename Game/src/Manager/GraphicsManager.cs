using System.Collections.Generic;
using System.Linq;
using Adapter;

namespace Game.src
{
	/// <summary>
	/// Purpose: Tell each Graphic Component to draw With the order being
	/// World Object, World Object info (Names, age, etc) and then UI
	/// </summary>
	public class GraphicsManager
	{
		public GraphicsManager(RenderAdapter adatper)
		{
			GraphicsComponent.SetAdapter(adatper);
		}

		public void Render(List<GraphicsComponent> world, List<GraphicsComponent> ui)
		{
			foreach (GraphicsComponent i in world)
			{
				i.Render();
			}

			foreach(IHaveInfo i in world.OfType<IHaveInfo>())
			{
				i.RenderInfo();
			}

			foreach(GraphicsComponent i in ui)
			{
				i.Render();
			}
		}
	}
}
