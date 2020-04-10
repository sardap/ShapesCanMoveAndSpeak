using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.src
{
	public class BeleiverDeleteComponet : DeleteComponet, IExternalDeletion
	{
		private bool _externalDeletion;

		public BeleiverDeleteComponet(GameObject holder) : base(holder)
		{
		}

		public void ExternalDelete()
		{
			if(Holder.GetComponent<SoundComponet>() != null)
			{
				Holder.GetComponent<SoundComponet>().AddToQue(SoundType.Delete);
				Holder.GetComponent<SoundComponet>().Play();
			}

			_externalDeletion = true;
		}

		protected override bool CheckToDelete()
		{
			return _externalDeletion || Holder.GetComponent<BeliverBeliefComponent>().Age >= Settings.BELIEVER_LATE_AGE;
		}
	}
}
