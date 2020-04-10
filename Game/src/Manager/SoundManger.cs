using System;
using System.Collections.Specialized;
using System.Collections.Generic;

namespace Game.src
{
	/// <summary>
	/// Purpose: Manges Game Sounds Which was going to be more than Just music
	/// </summary>
	public class SoundManger
	{
		private Sound _backGroundMusic;
		private Dictionary<SoundType, SoundComponet> _soundsPlaying = new Dictionary<SoundType, SoundComponet>();

		public SoundManger()
		{
			if(Settings.PLAY_MUSIC)
			{
				_backGroundMusic = new Sound(Settings.Instance.BackgroundMusicFileName, true, 0.2f);
			}
		}

		public void PlaySounds(List<SoundComponet> soundComponets)
		{
			foreach(SoundComponet i in soundComponets)
			{
				if(!_soundsPlaying.ContainsKey(i.SoundTypeToPlay))
				{
					_soundsPlaying.Add(i.SoundTypeToPlay, i);
					i.Play();
				}
				else
				{
					i.SoundTypeToPlay = SoundType.None;
				}
			}

			List<SoundType> finshed = new List<SoundType>();

			foreach(KeyValuePair<SoundType, SoundComponet> i in _soundsPlaying)
			{
				if(!i.Value.PlayingSound)
				{
					finshed.Add(i.Key);
				}
			}

			finshed.ForEach(i => _soundsPlaying.Remove(i));
		}

		public void StartBackGroundMusic()
		{
			_backGroundMusic.Play();
		}
	}
}
