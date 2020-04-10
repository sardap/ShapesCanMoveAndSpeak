using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	/// <summary>
	/// Purpose: Take the Mouseguru provide it with the set of buttons it uses	
	/// Then execute an action if used
	/// </summary>
	public abstract class UserInputComponent : Component
	{
		private Shape _bounds;

		public UserInputComponent(Shape bounds, GameObject holder) : base(holder)
		{
			_bounds = bounds ?? throw new NullReferenceException();
			InitliseResponseButtons();
		}

		protected Rectangle Bounds
		{
			get
			{
				return _bounds.HitBox;
			}
			set
			{
				_bounds = value;
			}
		}

		protected List<MouseButtonState> ReponseButtons
		{
			get;
			set;
		}

		public void ProcessInput(MouseGuru mouseGuru, KeyboardGuru keyboardGuru)
		{
			if(mouseGuru.OverLapped(GetHashCode(), Utils.ToScreen(Bounds), ReponseButtons))
			{
				Action(mouseGuru, keyboardGuru);
			}
		}

		protected abstract void Action(MouseGuru mouseGuru, KeyboardGuru keyboardGuru);

		protected abstract void InitliseResponseButtons();
	}
}
