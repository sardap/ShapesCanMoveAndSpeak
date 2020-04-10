using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	public class SelectComponent : Component
	{
		public SelectComponent(GameObject holder) : base(holder)
		{
		}

		public void ReciveCommand(ICommand command)
		{
			command.Excute(Holder);
		}
	}
}
