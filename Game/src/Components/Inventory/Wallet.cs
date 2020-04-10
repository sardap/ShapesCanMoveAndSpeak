using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	/// <summary>
	/// Purpose: To Store Money, Holder Type and handle all money transactions
	/// </summary>
	public class Wallet
	{
		private int _totalValue;
		// Refer to Money for justification for money being objects
		private List<Money> _money = new List<Money>();
		private string _type;

		public Wallet(string type)
		{
			_type = type;
		}

		public string HolderType
		{
			get
			{
				return _type;
			}
		}

		public int TotalValue
		{
			get
			{
				return _totalValue;
			}
		}

		/// <summary>
		/// Purpose: Adds Money to wallet and add the value of
		/// Money to total value then sorts money in low to high
		/// </summary>
		/// <param name="money"></param>
        public void Add(Money money)
		{
			if (money != null)
			{
				_totalValue += money.Worth;
				_money.Add(money);
				_money.Sort();
			}
		}

		public void Add(List<Money> toAdd)
		{
			toAdd.ForEach(i => Add(i));
		}

		public void Transfer(Wallet destWallet, int amount)
		{
			List<Money> result = new List<Money>();

			// Makes sure that wallet has enough
			if (TotalValue > amount)
			{
				while (amount > 0)
				{
					// Finds Closest Money Object transfers it into the 
					// result list
					result.Add(FindClosest(amount));
					
					amount -= result.Last().Worth;
					_totalValue -= result.Last().Worth;

					// Removes Money from wallet
					_money.Remove(result.Last());
				}
			}

			destWallet.Add(result);
		}

		/// <summary>
		/// Purpose: Destroys amount given
		/// </summary>
		/// <param name="amount"></param>
		public void Consume(int amount)
		{
			if (TotalValue > amount)
			{
				while (amount > 0)
				{
					Money match = FindClosest(amount);

					amount -= match.Worth;
					_totalValue -= match.Worth;

					_money.Remove(match);
				}
			}
			else
			{
				// If the wallet does not have enough money it removes all money
				_money = new List<Money>();
			}
		}

		private Money FindClosest(int target)
		{
			Money max = _money.Min();

			foreach (Money i in _money)
			{
				if (target - max.Worth > target - i.Worth)
				{
					max = i;
				}
				if (max.Worth == target)
				{
					break;
				}
			}

			return max;
		}



	}
}
