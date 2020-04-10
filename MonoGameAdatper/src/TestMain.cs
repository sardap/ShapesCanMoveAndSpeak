using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameAdatper
{
	class TestMain
	{
		public static void Main()
		{
			MonoGameDrawAdapter fuck = new MonoGameDrawAdapter();
			MonoGameUtilsAdapter shit = new MonoGameUtilsAdapter();

			shit.OpenGraphicsWindow("cool", 100, 100);
			while (true) ;
		}
	}
}
