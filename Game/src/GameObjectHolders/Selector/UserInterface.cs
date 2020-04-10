using System.Collections.Generic;
using System.Linq;
using System;
using SharedLibary;

namespace Game.src
{
	/// <summary>
	/// Purpose: Holds all User interface elements tells them all to process input
	/// </summary>
	public class UserInterlfaceContainer : GameObjectHolder, IHaveUpdate
	{
		private List<UserInterlfaceContainer> _userInterfaces = new List<UserInterlfaceContainer>();
		private List<GameObject> _elements = new List<GameObject>();
		private Selector _selector;
		private bool _deleteAfterOneLoop;

		public UserInterlfaceContainer(Selector selector, bool deleteAfterOneLoop)
		{
			_selector = selector ?? throw new NullReferenceException();
			_deleteAfterOneLoop = deleteAfterOneLoop;
		}

		public UserInterlfaceContainer(Selector selector) : this(selector, false)
		{
		}

		public override List<GameObject> GameObjects
		{
			get
			{
				List<GameObject> gameObjects = new List<GameObject>();

				gameObjects.AddRange(_elements);

				foreach(UserInterlfaceContainer i in _userInterfaces)
				{
					gameObjects.AddRange(i.GameObjects);
				}

				return gameObjects;
			}
		}

		public void Update(long deltaTime)
		{
			for(int i = 0; i < _userInterfaces.Count(); i++)
			{
				_userInterfaces[i].Update(deltaTime);

				if(_userInterfaces[i]._deleteAfterOneLoop)
				{
					_userInterfaces.Remove(_userInterfaces[i]);
				}
			}
		}

		public void ProcessInput(MouseGuru mouesGuru, KeyboardGuru keyboardGuru)
		{
			foreach (UserInterlfaceContainer i in _userInterfaces)
			{
				i.ProcessInput(mouesGuru, keyboardGuru);
			}

			// Reason: Newer objects are on top thus should be processed first
			List<UserInputComponent> list = GetComponents<UserInputComponent>();
			list.Reverse();

			foreach (UserInputComponent j in list)
			{
				j.ProcessInput(mouesGuru, keyboardGuru);
			}

			_selector.ExcuteCommands();
		}

		public void Add(GameObject toAdd)
		{
			if(toAdd != null)
			{
				_elements.Add(toAdd);
			}
		}

		public void Add(UserInterlfaceContainer toAdd)
		{
			if(toAdd != null)
			{
				_userInterfaces.Add(toAdd);
			}
		}
	}
}
