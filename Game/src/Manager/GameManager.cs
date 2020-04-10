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
	/// Purpose: Managers all other managers also holds factory, gametimer, Userinterface, world
	/// Is also responsible for distributing adapters
	/// </summary>
	public class GameManager
	{
		private Settings _settings = new Settings();
		private Factory _factory = new Factory();
		private GameTimer _tmr = new GameTimer(1);
		private World _world;
		private GraphicsManager _graphics;
		private InputManger _input;
		private SoundManger _sound;
		private UserInterfaceManger _ui;
		private CollsionManger _collsion;

		public GameManager(RenderAdapter renderAdapter, IUtilsAdapter utilsAdapter, IInputAdapter inputAdapter, IResourceAdapter resoruceAdapter)
		{
			_graphics = new GraphicsManager(renderAdapter);
			Utils.SetAdapter(utilsAdapter);
			_input = new InputManger(inputAdapter);
			ResoruceManger.SetAdapter(resoruceAdapter);

			SetUpGameWindow();
			LoadFonts();

			_world = new World(_factory, _settings.BackgroundMusicFileName);
			_ui = new UserInterfaceManger(_factory, _world);
			Statistics.SetWorld(_world);
			// Must be called After adapters are set
			_collsion = new CollsionManger();
			_sound = new SoundManger();

		}

		public void Start()
		{
			if(Settings.PLAY_MUSIC)
			{
				_sound.StartBackGroundMusic();
			}

			while (!Utils.WindowCloseRequested)
			{
				GameLoop();
			}
		}

		private void GameLoop()
		{
			_tmr.Restart();
			Utils.ProcessEvents();

			_ui.Update(_tmr.DeltaTime);
			_collsion.UpdateCollsions(_world.GetComponents<CollsionComponent>(), _ui.GetComponents<CollsionComponent>());
			Statistics.Update();
			_input.ProcessInput(_ui, _tmr);
			_world.Update(_tmr.DeltaTime);
			_sound.PlaySounds(_world.GetComponents<SoundComponet>());
			_graphics.Render(_world.GetComponents<GraphicsComponent>(), _ui.GetComponents<GraphicsComponent>());

			Utils.RefreshScreen();
		}

		private void LoadFonts()
		{
			ResoruceManger.LoadFont(new Font(Settings.DEFUALT_FONT_NAME, Settings.Instance.NameFontFileName, 10));
		}

		private void SetUpGameWindow()
		{
			Utils.OpenGraphicsWindow();
			Utils.SetCamreaPostion(Settings.Instance.StartPostion);
		}
	}
}
