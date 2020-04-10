using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameAdatper
{
	public static class MonoGameManger
	{
		private static CirclesGame _game = new CirclesGame();

		public static CirclesGame Game
		{
			get
			{
				return _game;
			}
		}

		public static GameWindow Window
		{
			get;
			set;
		}
	}
}
