using System.Collections.Generic;
using System.Linq;

namespace Game.src
{
	/// <summary>
	/// Purpose: Both the UI and World both hold Game Objects and have common ways in getting components
	/// </summary>
	public abstract class GameObjectHolder
	{
		public abstract List<GameObject> GameObjects
		{
			get;
		}

		public List<T> GetComponents<T>() where T : Component
		{
			List<T> result = new List<T>();

			foreach (GameObject i in GameObjects)
			{
				result.Add(i.GetComponent<T>());
			}

			return result.Where(i => i != null).ToList();
		}
	}
}
