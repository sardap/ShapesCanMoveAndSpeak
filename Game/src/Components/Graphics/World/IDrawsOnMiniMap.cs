using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	/// <summary>
	/// Purpose: attached to objects if they Draw on the MiniMap
	/// </summary>
	public interface IRenderOnMiniMap
    {
        void RenderOnMiniMap(Rectangle miniMapBounds);
	}
}
