using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adapter;
using SharedLibary;

namespace Game.src
{
	public class KeyboardGuru
	{
		private Dictionary<KeyCode, bool> _states = new Dictionary<KeyCode, bool>();

		public KeyboardGuru()
		{
		}

		public void Refersh(IInputAdapter adapter)
		{
			_states.Clear();

			foreach (KeyCode value in Enum.GetValues(typeof(KeyCode)))
			{
				_states.Add(value, adapter.KeyDown(value));
			}
		}

		public bool GetKeyState(KeyCode toFind)
		{
			return _states[toFind];
		}
	}
}