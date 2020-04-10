using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adapter;
using SharedLibary;

namespace SwinGameAdapter
{
	public class SwinGameResourceAdapter : IResourceAdapter
	{
		public SwinGameResourceAdapter()
		{
		}

		public void LoadFont(Font font)
		{
			SwinGameSDK.SwinGame.LoadFontNamed(font.ID, font.FileLocation, font.Size);
		}

		public void RemoveFont(Font font)
		{
			SwinGameSDK.SwinGame.FreeFont(GetSwinGameFont(font));
		}

		public SwinGameSDK.Font GetSwinGameFont(Font font)
		{
			return SwinGameSDK.SwinGame.LoadFontNamed(font.ID, font.FileLocation, font.Size);
		}

		public void LoopSound(string fileLocation, float volume)
		{
			SwinGameSDK.SwinGame.PlaySoundEffect(fileLocation, Int32.MaxValue, volume);
		}

		public void PlaySound(string fileLocation, float volume)
		{
			SwinGameSDK.SwinGame.PlaySoundEffect(fileLocation, volume);
		}

		public bool SoundPlaying(string fileLocaiton)
		{
			return SwinGameSDK.SwinGame.SoundEffectPlaying(fileLocaiton);
		}

		public void ReadySound(string fileLocation)
		{
			if (!SwinGameSDK.SwinGame.HasSoundEffect(fileLocation))
			{
				SwinGameSDK.SwinGame.LoadSoundEffect(fileLocation);
			}
		}
	}
}
