using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using SharedLibary;

namespace Game.src
{
	/// <summary>
	/// Purpose: Stores Statistics from a single world to be used with graphs
	/// </summary>
	public static class Statistics
	{
		private static World _world;
		// String is the Holders Type
		private static Dictionary<string, int> _totalMoney = new Dictionary<string, int>();

		// Total each Belief (A, R, G, B) into a list of each belief
		private static List<uint> _totalBelefs = new List<uint>();

		public static int TotalMoneyForType(string type)
		{
			return _totalMoney[type];
		}

		/// <summary>
		/// Purpose: Sets world for the stats class to use
		/// </summary>
		/// <param name="world"></param>
		public static void SetWorld(World world)
		{
			_world = world;
		}

		public static void Update()
		{
			UpdateTotalMoney();
			UpdateTotalBelifs();

			if (Settings.PRINT_STATS)
			{
				PrintInfo();
			}
		}

		private static string GetMoneyInfo
		{
			get
			{
				string result = string.Empty;

				foreach (string i in _totalMoney.Keys)
				{
					result += "HOLDER TYPE: " + i + " = " + _totalMoney[i] + "\n";
				}

				return result;
			}
		}

		private static string GetBeleifInfo
		{
			get
			{
				string reuslt = "Belief Info\n";

				reuslt += "A = " + _totalBelefs[0] + " ";
				reuslt += "R = " + _totalBelefs[1] + " ";
				reuslt += "G = " + _totalBelefs[2] + " ";
				reuslt += "B = " + _totalBelefs[3];

				return reuslt;
			}
		}

		private static void CleanTotalMoney()
		{
			List<string> fuck = _totalMoney.Keys.ToList();

			foreach (string i in fuck)
			{
				_totalMoney[i] = 0;
			}
		}

		private static void UpdateTotalMoney()
		{
			CleanTotalMoney();

			foreach (InventoryComponent i in _world.GetComponents<InventoryComponent>())
			{
				if(!_totalMoney.ContainsKey(i.Wallet.HolderType))
				{
					_totalMoney.Add(i.Wallet.HolderType, 0);
				}

				_totalMoney[i.Wallet.HolderType] += i.Wallet.TotalValue;
			}
		}

		private static void UpdateTotalBelifs()
		{
			_totalBelefs.Clear();

			for (int i = 0; i < 4; i++)
			{
				_totalBelefs.Add(0);
			}

			foreach (BeliefComponent i in _world.GetComponents<BeliefComponent>())
			{
				_totalBelefs[0] += i.A;
				_totalBelefs[1] += i.R;
				_totalBelefs[2] += i.G;
				_totalBelefs[3] += i.B;
			}
		}

		private static void PrintInfo()
		{
			Debug.WriteLine("NEW VALUES");

			Debug.WriteLine(GetMoneyInfo);

			Debug.WriteLine(GetBeleifInfo);
		}


	}
}
