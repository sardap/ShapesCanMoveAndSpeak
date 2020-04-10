using System;
using System.Collections.Generic;

using System.Linq;

namespace Game.src
{
	// @ToDo Put everything in a dict with Type, Object so i can get em fast (How to make with T?)
	/// <summary>
	/// Purpose: Holds an graphics component and collusion component
	/// </summary>
	public class GameObject
	{
		private List<Component> _componets = new List<Component>();

		public GameObject()
		{
		}

		/// <summary>
		/// Purpose: Adds a componet to the list
		/// </summary>
		/// <param name="toAdd"></param>
		public void Add(Component toAdd)
		{
			if(toAdd == null)
			{
				throw new NullReferenceException();
			}

			_componets.Add(toAdd);
		}

		public void Update(long deltaTime)
		{
			foreach (IHaveUpdate i in GetUpdateable())
			{
				i.Update(deltaTime);
			}
		}

		/// <summary>
		/// Purpose: Returns a component given the type
		/// </summary>
		/// <typeparam name="T"> Type </typeparam>
		/// <param name="components"></param>
		/// <returns></returns>
		public T GetComponent<T>() where T : Component
		{
			//return Components.Find(i => i.GetType() is T);
			foreach (Component i in _componets)
			{
				if (i is T)
				{
					return (T)i;
				}
			}

			return null;
		}

		private List<IHaveUpdate> GetUpdateable()
		{
			List<IHaveUpdate> result = new List<IHaveUpdate>();

			return _componets.FindAll(i => i is IHaveUpdate).OfType<IHaveUpdate>().ToList();
		}


	}
}
