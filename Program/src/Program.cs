using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.src;
using SwinGameAdapter;
using SplashKitAdapter;

namespace Program
{
	class Program
	{	 
		public static void Main(string[] args)
		{
			SelectVersion().Start();
		}

		private static GameManager SelectVersion()
		{
			const string SWINGAME_TAG = "0";
			const string SPLASHKIT_TAG = "1";

			string response = "";
			List<string[]> reponses = new List<string[]>
			{
				new string[2] { SWINGAME_TAG,  "SwinGame"},
				new string[2] { SPLASHKIT_TAG, "SplashKit" },
			};

			Console.WriteLine("Which Version Would you like?");

			// Writes Info from responses to console
			reponses.ForEach(i => Console.WriteLine("\t" + i[0] + " : " + i[1]));

			// Waits until the user types in an appropriate response
			while (!reponses.Any(i => i[0] == response))
			{
				Console.WriteLine("Please enter a number");
				response = Console.ReadLine();
			}

			switch (response)
			{
				case SWINGAME_TAG:
				{
					return new GameManager
					(
						new SwinGameDrawAdatper(),
						new SwinGameUtilsAdapter(),
						new SwinGameInputAdapter(),
						new SwinGameResourceAdapter()
					);
				}

				case SPLASHKIT_TAG:
				{
					return new GameManager
					(
						new SplashKitDrawAdapter(),
						new SplashKitUtilsAdapter(),
						new SplashKitInputAdapter(),
						new SplashKitReosurceAdapter()
					);
				}
			}

			return null;
		}
	}
}
