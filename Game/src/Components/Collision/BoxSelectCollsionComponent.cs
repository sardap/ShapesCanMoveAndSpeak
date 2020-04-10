using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	public class BoxSelectCollsionComponent : CollsionComponent
	{
		private Rectangle _rect;
		private Selector _selector;
		private bool _switch;

		public BoxSelectCollsionComponent(Selector selector, Rectangle bounds, GameObject holder) : base(holder)
		{
			_rect = bounds ?? throw new NullReferenceException();
			_selector = selector ?? throw new NullReferenceException();
		}

		public override Rectangle Bounds
		{
			get
			{
				return _rect;
			}
		}

		protected override void CollsionAction()
		{
			if(!Holder.GetComponent<BoxSelectGraphicalComponent>().Visible)
			{
				if(_switch)
				{
					_switch = false;
					ColliedObjects.ToList().ForEach(i => _selector.Add(i.Holder));
				}
			}
			else
			{
				_switch = true;
			}
		}

		public override void Clear()
		{
			if (CollsionDetector.Inside(Bounds, Settings.Instance.Gamebounds))
			{
				base.Clear();
			}
		}

		protected override void Add(CollsionComponent x)
		{
			base.Add(x);

		}
	}
}
