using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	class MoveCommand : ICommand
	{
		private delegate _targetMethod; 

		public MoveCommand(GameObject reciver, Delegate methodPointer)
		{

		}

		public void Excute()
		{
			
		}
	}
}
