using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	/// <summary>
	/// Purpose: Attached to classes that have a portrait similar to age of empires
	/// </summary>
	public interface IHavePortrait
	{
		void RenderPortrait(Rectangle bounds);

		string Title
		{
			get;
		}
	}
}
