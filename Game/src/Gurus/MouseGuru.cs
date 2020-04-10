using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adapter;
using SharedLibary;

namespace Game.src
{
	/// <summary>
	/// Purpose: To encapsulate information about the mouse and to distribute said information
	/// </summary>
	public class MouseGuru
	{
		// Stores each mouse button and their state
		private Dictionary<MouseButton, MouseState> _buttonStates = new Dictionary<MouseButton, MouseState>();
        private Point2D _screenPostion;
		private Point2D _rawPostion;
		private int _chosen;

		public MouseGuru()
		{
 		}

		public Point2D ScreenPostion
        {
            get
            {
                return _screenPostion;
            }
        }

		public Point2D RawPostion
		{
			get
			{
				return _rawPostion;
			}
		}

		public void Refresh(IInputAdapter adapter)
		{
			_buttonStates.Clear();

			_chosen = 0;

			_buttonStates.Add(MouseButton.LeftButton, GetState(adapter, MouseButton.LeftButton));
			_buttonStates.Add(MouseButton.RightButton, GetState(adapter, MouseButton.RightButton));
			_buttonStates.Add(MouseButton.MiddleButton, GetState(adapter, MouseButton.MiddleButton));

			_screenPostion = Utils.ToWorld(adapter.MousePostion());
			_rawPostion = adapter.MousePostion();
		}

		/// <summary>
		/// Returns if the Mouse is over the bounds if it has 
		/// not been used anywhere else
		/// </summary>
		/// <param name="bounds"> the area </param>
		/// <param name="buttons"> Which button state Combinations it should look for </param>
		/// <returns></returns>
		public bool OverLapped(int hash, Rectangle bounds, List<MouseButtonState> buttons)
		{
			if(_chosen == 0 && CollsionDetector.Inside(ScreenPostion, bounds))
			{
				if(buttons != null && buttons.Any(i => _buttonStates[i.Button] == i.State))
				{
					_chosen = hash;
					return true;
				}
			}

			return false;
			
		}

		public bool Clicked(int hash, MouseButton button)
		{
			return CheckIfChosen(hash) && _buttonStates[button] == MouseState.Clicked;
		}

		public bool Down(int hash, MouseButton button)
		{
			return CheckIfChosen(hash) && _buttonStates[button] == MouseState.Down;
		}

		public bool Up(int hash, MouseButton button)
		{
			return CheckIfChosen(hash) && _buttonStates[button] == MouseState.Up;
		}

		private bool CheckIfChosen(int hash)
		{
			return _chosen == hash;
		}

		private MouseState GetState(IInputAdapter adapter, MouseButton button)
		{
			if(adapter.MouseClicked(button))
			{
				return MouseState.Clicked;
			}

			if (adapter.MouseDown(button))
			{
				return MouseState.Down;
			}

			return MouseState.Up;
		}
	}
}
