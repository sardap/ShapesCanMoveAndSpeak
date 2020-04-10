using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;
using Adapter;

namespace Game.src
{
	/// <summary>
	/// Purpose: Used to render World game objects has update, center, Colour and Movement component
	/// </summary>
	public abstract class WorldGraphicsComponent : GraphicsComponent, IHaveUpdate
	{
		public WorldGraphicsComponent(GameObject holder) : base(holder)
		{
		}

		public Colour Colour
		{
			get;
			set;
		}

		public abstract Point2D Center
		{
			get;
			set;
		}

		// Reason why this needs to have a movement component is because
		// the graphics component knows where it is
		protected MoveComponet Move
		{
			get
			{
				return Holder.GetComponent<MoveComponet>();
			}
		}

		public abstract void Update(long deltaTime);
	}
}
