using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.src
{
	public abstract class DeleteComponet : Component
	{
		public DeleteComponet(GameObject holder) : base(holder)
		{
		}

		public bool Delete
		{
			get
			{


				return CheckToDelete();
			}
		}

		protected abstract bool CheckToDelete();
	}
}
