using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	public class UserInterfaceManger : GameObjectHolder, IHaveUpdate
	{
		private Selector _selector;
		private UserInterlfaceContainer _baseUI;
		private Factory _factory;

		public UserInterfaceManger(Factory factory, World world)
		{
			_factory = factory ?? throw new NullReferenceException();

			_selector = new Selector(world);
			_baseUI = new UserInterlfaceContainer(_selector);

			AddStaticUI(world);
		}

		public Selector Selector
		{
			get
			{
				return _selector;
			}
		}

		public override List<GameObject> GameObjects
		{
			get
			{
				return _baseUI.GameObjects;
			}
		}

		public void Update(long deltaTime)
		{
			_baseUI.Update(deltaTime);
			ReCreateUIElements();
		}

		public void ProcessInput(MouseGuru mouseGuru, KeyboardGuru keyboardGuru)
		{
			_baseUI.ProcessInput(mouseGuru, keyboardGuru);
		}

		private void Add(UserInterlfaceContainer toAdd)
		{
			_baseUI.Add(toAdd);
		}

		private void Add(GameObject toAdd)
		{
			_baseUI.Add(toAdd);
		}

		private void AddStaticUI(World world)
		{
			Add(_factory.CreateBoxSelect(_selector));
			Add(_factory.CreateMiniMap(world, Settings.Instance.MiniMapSize));
		}

		private void ReCreateUIElements()
		{
			Add
			(
				_factory.CreateInfoPannel
				(
					_selector,
					new Rectangle
					(
						0,
						0 + (Utils.ScreenHeight() - Settings.Instance.MiniMapSize.Height),
						Utils.ScreenWidth() - Settings.Instance.MiniMapSize.Width,
						Settings.Instance.MiniMapSize.Height
					)
				)
			);

			//LayersOfUIExample();
		}

		private void LayersOfUIExample()
		{
			UserInterlfaceContainer layer1 = new UserInterlfaceContainer(_selector);
			layer1.Add(_factory.CreateInfoPannel(_selector, new Rectangle(0, 0, 100, 200)));
			UserInterlfaceContainer layer2 = new UserInterlfaceContainer(_selector);
			layer2.Add(_factory.CreateInfoPannel(_selector, new Rectangle(500, 0, 100, 200)));
			UserInterlfaceContainer layer3 = new UserInterlfaceContainer(_selector);
			layer3.Add(_factory.CreateInfoPannel(_selector, new Rectangle(700, 0, 100, 200)));

			layer2.Add(layer3);
			layer1.Add(layer2);
			Add(layer1);
		}
	}
}
