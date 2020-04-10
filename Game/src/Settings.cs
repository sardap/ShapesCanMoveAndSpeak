using System;
using System.Collections.Generic;
using System.IO;
using SharedLibary;


namespace Game.src
{
	/// <summary>
	/// Purpose: A static class that stores game settings EG Debug mode, camera Speed, file locations
	/// With the aim to have each of these read from a file
	/// </summary>
	public class Settings
	{
		private const string DEFUALT_FILE_LOCATION = @"Resoruces\Settings.txt";

		public const string MINE_SOUND_FILENAME = @"Resoruces\sounds\MineSelect.wav";

		public const bool SCREENONLY = false;
		public const float CAMERA_SPEED = 10.5f;

		public const uint SPAWN_INTERVAL = 5000;

		public const bool PRINT_STATS = true;
		public const bool PLAY_MUSIC = false;

		public const int MAX_OBJECTS = 1000;
		public const int MINING_SIZE_MUL = 20;
		public const int BELIEVER_LATE_AGE = 100;
		public const double BELIVER_SPEED_MIN = 2;
		public const long BELIVER_MONEY_DRAN_INTEVERAL = 1000;
		public const long BELIVER_COMAPRE_INTERVAL = 5000;
		public const long BELIVER_MAX_MINE_TIME = 500;
		public const long AGE_DIVSOR = 150;

		public const int PORTRAT_SPACING = 12;
		public const int PORTRAT_SIZE = 65;

		public const int QUADTREE_MAX_OBJECTS = 5;
		public const int QUADTREE_MAX_LEVELS = 50;

		public const KeyCode KEY_UP_MOVEMENT = KeyCode.WKey;
		public const KeyCode KEY_DOWN_MOVEMENT = KeyCode.SKey;
		public const KeyCode KEY_LEFT_MOVEMENT = KeyCode.AKey;
		public const KeyCode KEY_RIGHT_MOVEMENT = KeyCode.DKey;
		public const KeyCode KEY_FAST_CAMREA = KeyCode.ShiftKey;
		public const KeyCode FASTFOWARD_KEY = KeyCode.EqualsKey;
		public const KeyCode REWIND_KEY = KeyCode.MinusKey;
		public const KeyCode DELETE_KEY = KeyCode.PKey;

		public const double TIME_FACTOR_INTERVAL = 0.1;

		public const string DEFUALT_FONT_NAME = "standard";

		private const float MINIMAP_DIVOSR = 3.5f;
		private const int GAME_BOUNDS_MUTIPLIER = 4;


		private static Settings _singleton = null;

		public static Settings Instance
		{
			get
			{
				return _singleton;
			}
		}

		private static void InitliseSignleton(Settings settings)
		{
			if (_singleton != null)
			{
				throw new SingletonAlreadyCreatedException();
			}

			_singleton = settings;
		}

		private string _backgroundMusicFileName = @"Resoruces\sounds\background01.wav";
		// I should be using a loop and just adding one to the end so then i could add more files and it would just work
		private string _beliverSelectSoundsFileName = @"Resoruces\sounds\SelectSound.wav";
		private string _namesFileName = @"Resoruces\Names.txt";
		private string _nameFontFileName = @"Resoruces\fonts\cour.ttf";
		private string _windowTitle = "Circles?";
		private int _screenWidth = 800;
		private int _screenHieght = 600;

		public Settings(string fileLocation)
		{
			InitliseSignleton(this);

			ReadSettingsFile(fileLocation);
		}

		public Settings() : this(DEFUALT_FILE_LOCATION)
		{
		}
		
		public string BackgroundMusicFileName
		{
			get
			{
				return _backgroundMusicFileName;
			}
		}

		public string BelieverSelectSoundFileName
		{
			get
			{
				return _beliverSelectSoundsFileName;
			}
		}

		public string BeliverMoveSoundFileName
		{
			get
			{
				return  @"Resoruces\sounds\MoveSound.wav";
			}
		}

		public string BeliverDeathSoundFileName
		{
			get
			{
				return @"Resoruces\sounds\DeathSound.wav";
			}
		}


		public string NamesFileName
		{
			get
			{
				return _namesFileName;
			}
		}

		public string NameFontFileName
		{
			get
			{
				return _nameFontFileName;
			}
		}

		public string WindowTitle
		{
			get
			{
				return _windowTitle;
			}
		}

		public int ScreenWidth
		{
			get
			{
				return _screenWidth;
			}
		}

		public int ScreenHeight
		{
			get
			{
				return _screenHieght;
			}
		}

		public const bool DEBUG = true;

		public Rectangle Gamebounds 
		{
			get
			{
				return new Rectangle(0, 0, Utils.ScreenWidth() * GAME_BOUNDS_MUTIPLIER, Utils.ScreenHeight() * GAME_BOUNDS_MUTIPLIER);
			}
		}

		public Point2D StartPostion
		{
			get
			{
				return Gamebounds.Center.Subtract(Utils.CameraPostionRectangle().WidthAndHeight.Divide(2));
			}
		}

		public Rectangle MiniMapSize
		{
			get
			{
				return new Rectangle
				(
					Utils.ScreenWidth() - Convert.ToInt32(Utils.ScreenWidth() / MINIMAP_DIVOSR),
					Utils.ScreenHeight() - Convert.ToInt32(Utils.ScreenHeight() / MINIMAP_DIVOSR),
					Convert.ToInt32(Utils.ScreenWidth() / MINIMAP_DIVOSR),
					Convert.ToInt32(Utils.ScreenHeight() / MINIMAP_DIVOSR)
				);
			}

		}

		private void ReadSettingsFile(string fileLocation)
		{
			using (StreamReader reader = new StreamReader(fileLocation))
			{
				while (!reader.ReadLine().Contains("[")) ;

				_backgroundMusicFileName = PraseLine(reader.ReadLine());
				_namesFileName = PraseLine(reader.ReadLine());
				_nameFontFileName = PraseLine(reader.ReadLine());

				while (!reader.ReadLine().Contains("[")) ;
				_windowTitle = PraseLine(reader.ReadLine());
				_screenWidth = Int32.Parse(PraseLine(reader.ReadLine()));
				_screenHieght = Int32.Parse(PraseLine(reader.ReadLine()));
			}
		}

		private string PraseLine(string line)
		{
			return line.Substring(line.IndexOf("=") + 2);
		}
	}
}
