using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	/// <summary>
	/// Purpose: Used to Hold a list of World objects which are selected given 
	/// to diffrent User Interface Elements
	/// </summary>
	public class Selector : GameObjectHolder
	{
		private HashSet<GameObject> _selected = new HashSet<GameObject>();
		private World _world;

		public Selector(World world)
		{
			_world = world ?? throw new NullReferenceException();
		}

		public override List<GameObject> GameObjects
		{
			get
			{
				_selected.RemoveWhere(i => _world.GameObjects.IndexOf(i) == -1);

				return _selected.ToList();
			}
		}

		public ICommand Command
		{
			get;
			set;
		}

		private bool _soundNotPlayedThisLoop;

		public void Add(GameObject toAdd)
		{
			if (toAdd != null && toAdd.GetComponent<SelectComponent>() != null)
			{
				_selected.Add(toAdd);

				if (_selected.Count == 1 && _soundNotPlayedThisLoop)
				{
					_soundNotPlayedThisLoop = false;

					if (toAdd.GetComponent<SoundComponet>() != null)
					{
						toAdd.GetComponent<SoundComponet>().AddToQue(SoundType.Select);
					}
				}
			}
		}

		public void Clear()
		{
			_selected.Clear();
			_soundNotPlayedThisLoop = true;
		}

		public void ExcuteCommands()
		{
			if(Command != null)
			{
				foreach (SelectComponent i in GetComponents<SelectComponent>())
				{
					i.ReciveCommand(Command);
				}
			}

			Command = null;
		}
	}
}
