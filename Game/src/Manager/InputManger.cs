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
	/// Purpose : Process input from user Must have an input adapter
	/// </summary>
	public class InputManger
	{
		private IInputAdapter _inputAdapter;

		private MouseGuru _mouseGuru = new MouseGuru();
		private KeyboardGuru _keyboardGuru = new KeyboardGuru();

		public InputManger(IInputAdapter adapter)
		{
			_inputAdapter = adapter ?? throw new NullReferenceException();
		}

		public void ProcessInput(UserInterfaceManger ui, GameTimer timer)
		{
			_mouseGuru.Refresh(_inputAdapter);
			_keyboardGuru.Refersh(_inputAdapter);

			ui.ProcessInput(_mouseGuru, _keyboardGuru);

			HandleCameraMovement(_keyboardGuru);
			HandleSpeedInput(timer, _keyboardGuru);
			HandleCommandInput(ui.Selector);
		}

		private void HandleCameraMovement(KeyboardGuru keyboardGuru)
		{
			Rectangle newPostion = Utils.CameraPostionRectangle();
			float camreaSpeed = Settings.CAMERA_SPEED;

			if (_inputAdapter.KeyDown(Settings.KEY_FAST_CAMREA))
			{
				camreaSpeed *= 5;
			}

			if (_inputAdapter.KeyDown(Settings.KEY_LEFT_MOVEMENT))
			{
				newPostion.X -= camreaSpeed;
			}

			if (_inputAdapter.KeyDown(Settings.KEY_RIGHT_MOVEMENT))
			{
				newPostion.X += camreaSpeed;
			}

			if (_inputAdapter.KeyDown(Settings.KEY_UP_MOVEMENT))
			{
				newPostion.Y -= camreaSpeed;
			}

			if (_inputAdapter.KeyDown(Settings.KEY_DOWN_MOVEMENT))
			{
				newPostion.Y += camreaSpeed;
			}

			if (Utils.InsideGameBounds(newPostion))
			{
				SetCameraPostion(newPostion);
			}
		}

		private void SetCameraPostion(Point2D location)
		{
			Utils.SetCamreaPostion(location);
		}

		private void HandleSpeedInput(GameTimer timer, KeyboardGuru keyboardGuru)
		{
			if(keyboardGuru.GetKeyState(Settings.FASTFOWARD_KEY))
			{
				timer.Speed += Settings.TIME_FACTOR_INTERVAL;
			}

			if(keyboardGuru.GetKeyState(Settings.REWIND_KEY))
			{
				timer.Speed += Settings.TIME_FACTOR_INTERVAL * -1;
			}
		}

		private void HandleCommandInput(Selector selector)
		{
			if (_inputAdapter.MouseClicked(MouseButton.RightButton))
			{
				selector.Command = new MoveCommand(_inputAdapter.MousePostion());
			}
			else if (_inputAdapter.KeyTyped(Settings.DELETE_KEY))
			{
				selector.Command = new DeleteCommand();
			}
		}
	}
}
