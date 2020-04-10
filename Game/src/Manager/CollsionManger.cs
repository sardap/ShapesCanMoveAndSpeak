using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	/// <summary>
	/// Purpose: To detect collisions between every CollsionComponent given
	/// </summary>
	public class CollsionManger
	{
		private QuadTree _quadTree = new QuadTree(0, Settings.Instance.Gamebounds);

		public CollsionManger()
		{
		}

		public void UpdateCollsions(List<CollsionComponent> worldComponents, List<CollsionComponent> uiComponents)
		{
			// Combines both lists
			List<CollsionComponent> collisions = new List<CollsionComponent>();
			collisions.AddRange(worldComponents);
			collisions.AddRange(uiComponents);

			// Clears Each objects collision list
			ClearCollsions(collisions);

			_quadTree.Process(collisions);
			HandleColsions(collisions);
		}

		private void ClearCollsions(List<CollsionComponent> collsions)
		{
			foreach (CollsionComponent i in collsions)
			{
				i.Clear();
			}
		}

		protected void HandleColsions(List<CollsionComponent> collisions)
		{
			foreach (CollsionComponent i in collisions)
			{
				i.HandleCollsion();
			}
		}
	}
}
