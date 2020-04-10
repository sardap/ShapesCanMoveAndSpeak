using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.src
{
	public class DeleteCommand : ICommand
	{
		public DeleteCommand()
		{
		}

		public void Excute(GameObject excutie)
		{
			if (excutie.GetComponent<DeleteComponet>() is IExternalDeletion)
			{
				(excutie.GetComponent<DeleteComponet>() as IExternalDeletion).ExternalDelete();
			}
		}
	}
}
