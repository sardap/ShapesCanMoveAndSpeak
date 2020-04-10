using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	/// <summary>
	/// Purpose: Used for movement across the program
	/// </summary>
	public class MoveComponet : Component
	{
		private Point2D _target;
		private double _speed;

		public MoveComponet(double speed, Point2D startLocation, GameObject holder) : base(holder)
		{
			_target = new Point2D(startLocation);
			_speed = speed;
		}

		public void SetTarget(Point2D target)
		{
			_target = target;

			if(Holder.GetComponent<SoundComponet>() != null)
			{
				Holder.GetComponent<SoundComponet>().AddToQue(SoundType.Move);
			}
		}

		public virtual void Move(WorldGraphicsComponent toMove, long deltaTime)
		{
			double speed = _speed * deltaTime;

			if (!CollsionDetector.OverLapping(toMove.Center, _target))
			{
				/*
					I hate movement so i stole this is form here 
					http://stackoverflow.com/questions/13849185/moving-an-object-along-a-straight-line-at-a-constant-speed-from-point-a-to-b
				*/

				double tx = _target.X - toMove.Center.X;
				double ty = _target.Y - toMove.Center.Y;
				double dist = Math.Sqrt(tx * tx + ty * ty);
				double rad = Math.Atan2(ty, tx);
				double angle = rad / Math.PI * 180;

				double velX = (tx / dist) * speed;
				double velY = (ty / dist) * speed;

				toMove.Center = toMove.Center.Add(new Point2D(velX, velY));
			}


		}
	}
}
