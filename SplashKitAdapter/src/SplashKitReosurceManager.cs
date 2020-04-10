using System;
using System.Collections.Generic;
using System.Text;
using SharedLibary;
using Adapter;

namespace SplashKitAdapter
{
    public class SplashKitReosurceAdapter : IResourceAdapter
    {
		public SplashKitReosurceAdapter()
		{
		}

		public void LoadFont(Font font)
		{
			SplashKitSDK.SplashKit.LoadFont(font.ID, font.FileLocation);
		}

		public void RemoveFont(Font font)
		{
			// Add when used
			throw new NotImplementedException();
		}

		public void LoopSound(string fileLocation, float volume)
		{
			SplashKitSDK.SplashKit.PlaySoundEffect(fileLocation, Int32.MaxValue, volume);
		}

		public void PlaySound(string fileLocation, float volume)
		{
			SplashKitSDK.SplashKit.PlaySoundEffect(fileLocation, volume);
		}

		public bool SoundPlaying(string fileLocaiton)
		{
			return SplashKitSDK.SplashKit.SoundEffectPlaying(fileLocaiton);
		}

		public void ReadySound(string fileLocation)
		{
			if(SplashKitSDK.SplashKit.HasSoundEffect(fileLocation))
			{
				SplashKitSDK.SplashKit.LoadSoundEffect(fileLocation, fileLocation);
			}
		}

	}
}
