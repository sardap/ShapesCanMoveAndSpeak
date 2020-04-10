using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	public abstract class CollsionComponent : Component
	{
		private HashSet<CollsionComponent> _colliedObjects = new HashSet<CollsionComponent>();

		public CollsionComponent(GameObject holder) : base(holder)
		{
		}

		public abstract Rectangle Bounds
		{
			get;
		}

		protected HashSet<CollsionComponent> ColliedObjects
		{
			get
			{
				return _colliedObjects;
			}

		}

		public void CheckCollsion(CollsionComponent x)
		{
			if(CollsionDetector.OverLapping(Bounds, x.Bounds))
			{
				Add(x);
			}
		}

		public void HandleCollsion()
		{
			CollsionAction();
		}

		public virtual void Clear()
		{
			ColliedObjects.Clear();
		}

		protected virtual void Add(CollsionComponent x)
		{
			ColliedObjects.Add(x);
		}

		protected abstract void CollsionAction();
	}
}
