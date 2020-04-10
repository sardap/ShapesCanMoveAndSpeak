using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.src
{
	public interface IExternalDeletion
	{
		// Reason why this is a method and not a set becuase When asked if somthing
		// Needs to be deleted it calls an method and returns the method
		void ExternalDelete();
	}
}
