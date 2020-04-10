using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	public class PortraitUserInputComponent : ButtonUserInputComponent
	{
		// Portart of this object
		private GameObject _gameObject;
		private Selector _selector;

		public PortraitUserInputComponent(Selector selector, GameObject subject, GameObject holder) : base(new Rectangle(), holder)
		{
			_gameObject = subject ?? throw new NullReferenceException();
			_selector = selector ?? throw new NullReferenceException();
			Bounds = Holder.GetComponent<PortatGraphicsComponent>().Bounds ?? throw new NullReferenceException();
		}

		protected override void Action(MouseGuru mouseGuru, KeyboardGuru keyboardGuru)
		{
			_selector.Clear();
			_selector.Add(_gameObject);

			MoveCameraToSubject();
		}

		/// <summary>
		/// Moves the Camera to the Subject
		/// </summary>
		private void MoveCameraToSubject()
		{
			WorldGraphicsComponent wgc = _gameObject.GetComponent<WorldGraphicsComponent>();

			Utils.SetCamreaCenter(wgc.Center);
		}
	}
}
