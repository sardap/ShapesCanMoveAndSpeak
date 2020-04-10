using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	public class BeliverCollisionComponent : CollsionComponent, IHaveUpdate
	{
		private BelieverGraphicalComponent _graphics;
		private MoveComponet _move;
		private long _timeToMine;

		public BeliverCollisionComponent(GameObject holder) : base(holder)
		{
			_graphics = holder.GetComponent<BelieverGraphicalComponent>();
			_move = holder.GetComponent<MoveComponet>();
			_timeToMine = Settings.BELIVER_MAX_MINE_TIME;
		}

		public override Rectangle Bounds
		{
			get
			{
				return _graphics.Bounds;
			}
		}

		public bool ReadyToMine()
		{
			if (_timeToMine <= 0)
			{
				_timeToMine = Math.Max
				(
					(
						Settings.BELIVER_MAX_MINE_TIME - (Convert.ToUInt32(Holder.GetComponent<BeliefComponent>().Size) * Settings.MINING_SIZE_MUL)
					), 
					0
				);

				return true;
			}

			return false;
		}

		public void Update(long deltaTime)
		{
			_timeToMine -= deltaTime;
		}

		protected override void CollsionAction()
		{
			foreach (CollsionComponent i in ColliedObjects.ToList().FindAll(i => i.Holder.GetComponent<BeliefComponent>() != null))
			{
				Holder.GetComponent<BeliefComponent>().Compare(i.Holder.GetComponent<BeliefComponent>());
			}
		}
	}
}
