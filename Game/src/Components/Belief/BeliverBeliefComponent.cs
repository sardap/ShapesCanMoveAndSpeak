using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	/// <summary>
	/// Purpose: Used for as Belivers belief component Which is a horrific name
	/// </summary>
	public abstract class BeliverBeliefComponent : BeliefComponent
	{
		protected const long COMAPRE_INTERVAL = Settings.BELIVER_COMAPRE_INTERVAL;

		// Used to store the age of a beleiver
		private Age _age = new Age();
		private InventoryComponent _inventory;
		private string _name;
		private uint _lateAge;
		// Used to count how long until Money can be drained again
		private long _timeToDrainMoney = 0;

		public BeliverBeliefComponent(string name, uint lateAge, GameObject holder) : base(holder)
		{
			_inventory = holder.GetComponent<InventoryComponent>() ?? throw new NullReferenceException();

			_lateAge = lateAge;
			_name = name;
		}

		/// <summary>
		/// Purpose: Used for by dirvired classes
		/// </summary>
		protected InventoryComponent Inventory
		{
			get
			{
				return _inventory;
			}
		}

		public string Name
		{
			get
			{
				return _name;
			}
		}

		public uint Age
		{
			get
			{
				return (uint)_age.Value;
			}
		}

		// Time Until the object can compare it's beleifs 
		protected long TimeToCompare
		{
			get;
			set;
		}

		public override void Update(long deltaTime)
		{
			TimeToCompare -= deltaTime;
			UpdateAge(deltaTime);
			UpdateBeleifs();
		}

		/// <summary>
		/// Purpose: used to check if the object is ready to compare it's beleifs
		/// </summary>
		/// <returns></returns>
		public override bool ReadyToCompare()
		{
			if (TimeToCompare <= 0)
			{
				UpdateTimeToComapre();
				return true;
			}

			return false;
		}

		protected int SingleCompare(byte comapre, byte toComapre)
		{
			/*
			double partA = Math.Max(((double)(comapre - toComapre) / (double)comapre), 0);
			// @Bad 
			if(Double.IsNaN(partA))
			{
				partA = 1;
			}
			int temp = comapre + Convert.ToInt32(toComapre * Math.Abs(partA));
			comapre = Convert.ToByte(Math.Min(temp, 255));
			return comapre;
			*/
			
			if(comapre > toComapre)
			{
				comapre -= toComapre;
			}
			else
			{
				comapre += toComapre;
			}

			return comapre;
		}

		protected abstract void UpdateTimeToComapre();

		protected abstract void UpdateBeleifs();

		private void UpdateAge(long deltaTime)
		{
			_age.Update(deltaTime);

			if (Age > _lateAge)
			{
				DrainMoney(deltaTime);
			}

			A = Convert.ToByte(Math.Min(Age, 255));
		}

		// Drains a random amount of money from the beleiver
		private void DrainMoney(long deltaTime)
		{
			_timeToDrainMoney -= deltaTime;

			if (_timeToDrainMoney <= 0)
			{
				Inventory.Wallet.Consume(Utils.Random(50, 100));
				_timeToDrainMoney = Settings.BELIVER_MONEY_DRAN_INTEVERAL;
			}
		}

	}
}
