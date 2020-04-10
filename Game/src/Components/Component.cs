using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.src
{
	public abstract class Component
	{
		private GameObject _holder;

		public Component(GameObject holder)
		{
			_holder = holder ?? throw new NullReferenceException();
		}

		public GameObject Holder
		{
			get
			{
				return _holder;
			}
		}
	}
}
