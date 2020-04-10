namespace Game.src
{
	/// <summary>
	/// Purpose: Used to play Sounds from file Reason 
	/// For not just using the Sound player anywhere is that
	/// If i switch form .net Standard i can just Change sound 
	/// Related code here and only here
	/// </summary>
	public class Sound
	{
		private string _fileName;
		private bool _loop;
		// 1 is full 0  is none
		private float _volume;

		public Sound(string fileName, bool looping, float level)
		{
			_fileName = fileName;
			_loop = looping;
			_volume = level;
			ResoruceManger.LoadSound(this);
		}

		public Sound(string fileName, bool looping) : this(fileName, looping, 1)
		{
			}

		public Sound(string fileName) : this(fileName, false)
		{
		}

		public bool Playing
		{
			get
			{
				return ResoruceManger.SoundPlaying(this);
			}
		}

		public string FileName
		{
			get
			{
				return _fileName;
			}
		}

		public bool Loop
		{
			get
			{
				return _loop;
			}
		}

		public float Volume
		{
			get
			{
				return _volume;
			}
		}

		public void Play()
		{
			ResoruceManger.PlaySound(this);
		}
	}
}
