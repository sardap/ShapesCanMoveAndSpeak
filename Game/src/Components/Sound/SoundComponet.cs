using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.src
{
	public class SoundComponet : Component
	{
		private Dictionary<SoundType, List<Sound>> _sounds = new Dictionary<SoundType, List<Sound>>();
		private Sound _lastSoundPlayed;

		public SoundComponet(GameObject holder) : base(holder)
		{
		}

		public SoundType SoundTypeToPlay
		{
			get;
			set;
		}

		public bool PlayingSound
		{
			get
			{
				return ResoruceManger.SoundPlaying(_lastSoundPlayed);
			}
		}

		public void Play()
		{
			if(!PlayingSound && _sounds.ContainsKey(SoundTypeToPlay))
			{
				_lastSoundPlayed = _sounds[SoundTypeToPlay].RandomElement();
				_lastSoundPlayed.Play();
				SoundTypeToPlay = SoundType.None;
			}
		}

		public void Add(SoundType type, Sound sound)
		{
			if(sound == null)
			{
				throw new NullReferenceException();
			}

			if (!_sounds.ContainsKey(type))
			{
				_sounds.Add(type, new List<Sound>());
			}

			_sounds[type].Add(sound);
		}

		public void AddToQue(SoundType type)
		{
			if(_sounds.ContainsKey(type) && !ResoruceManger.SoundPlaying(_lastSoundPlayed))
			{
				SoundTypeToPlay = type;
			}
		}
	}
}
