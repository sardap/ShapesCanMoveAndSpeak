using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Game.src
{
	public class SingletonAlreadyCreatedException : Exception
	{
		public SingletonAlreadyCreatedException() : base("Singleton has already been created")
		{
		}
	}
}
