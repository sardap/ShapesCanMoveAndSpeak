using System;
using System.Collections.Generic;
using SharedLibary;

namespace Game.src
{
	/// <summary>
	/// Purpose: Process/handles input for BoxSelect
	/// </summary>
    public class BoxSelectInputComponent : UserInputComponent
    {
		// Needs to tell the graphical component if it is active
		private BoxSelectGraphicalComponent _graphics;
		// Needs to set the action of the collision component
        private BoxSelectState _state;
		private InputAction _action;
		private Selector _selector;

        public BoxSelectInputComponent(Rectangle bounds, Selector selector, GameObject holder) : base(bounds, holder)
        {
            _graphics = Holder.GetComponent<BoxSelectGraphicalComponent>() ?? throw new NullReferenceException();
			_selector = selector ?? throw new NullReferenceException(); 
		}

        protected override void Action(MouseGuru mouseGuru, KeyboardGuru keyboardGuru)
        {
            switch (_state)
            {
                case BoxSelectState.NotActive:
                {
                    SetAction(InputAction.Nothing);

                    if (mouseGuru.Down(GetHashCode(), MouseButton.LeftButton))
                    {
						_selector.Clear();
						// Start Selcting
						SwitchSelecting(mouseGuru.ScreenPostion);
                        _state = BoxSelectState.Active;
                    }


					break;
                }
                case BoxSelectState.Active:
                {
                    if (mouseGuru.Up(GetHashCode(), MouseButton.LeftButton))
                    {
						// Stop Selecting
						SwitchSelecting(mouseGuru.ScreenPostion);
						_state = BoxSelectState.NotActive;
                    }
                    else
                    {
                        _graphics.UpdatePostion(mouseGuru.ScreenPostion);
                    }

                    break;
                }
            }
        }

		protected override void InitliseResponseButtons()
		{
			ReponseButtons = new List<MouseButtonState>
			{
				new MouseButtonState { Button = MouseButton.LeftButton, State = MouseState.Down },
				new MouseButtonState { Button = MouseButton.LeftButton, State = MouseState.Up },
				new MouseButtonState { Button = MouseButton.RightButton, State = MouseState.Clicked }
			};
		}

		private void SwitchSelecting(Point2D postion)
        {
			_graphics.Reset(postion);
		}

		private void SetAction(InputAction newAction)
		{
			_action = newAction;
		}
	}
}
