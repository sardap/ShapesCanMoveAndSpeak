using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.src
{
	/// <summary>
	/// Purpose: can be attached to objects and they "Should" Update without
	/// additional code 
	/// </summary>
	public interface IHaveUpdate
	{
		void Update(long deltaTime);
	}
}
