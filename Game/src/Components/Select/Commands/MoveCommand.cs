using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	public class MoveCommand : ICommand
	{
		private Point2D _target;

		public MoveCommand(Point2D target)
		{
			if(CollsionDetector.Inside(target, Settings.Instance.MiniMapSize))
			{
				 _target = Utils.FromBoundsToWorld(target, Settings.Instance.MiniMapSize);
			}
			else
			{
				_target = Utils.ToWorld(target);
			}
		}

		public void Excute(GameObject excutie)
		{
			if (excutie.GetComponent<MoveComponet>() != null)
			{
				excutie.GetComponent<MoveComponet>().SetTarget(_target);
			}
		}
	}
}
