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
	/// Purpose : Manages game resources which includes Fonts but would also include Bitmaps
	/// if they were added
	/// </summary>
	public static class ResoruceManger
	{
		private static Dictionary<string, Font> _loadedFonts = new Dictionary<string, Font>();
		private static HashSet<Sound> _loadedSounds = new HashSet<Sound>();

		private static IResourceAdapter Adapter
		{
			get;
			set;
		}

		public static void SetAdapter(IResourceAdapter adapter)
		{
			Adapter = adapter ?? throw new NullReferenceException();
		}

		public static void LoadFont(Font font)
		{
			_loadedFonts.Add(font.ID, font);
			Adapter.LoadFont(font);
		}

		public static void RemoveFont(string id)
		{
			if (_loadedFonts[id] != null)
			{
				Adapter.RemoveFont(_loadedFonts[id]);
				_loadedFonts.Remove(id);
			}
		}

		/// <summary>
		/// Purpose : Returns a font from id will create a new font if one does not
		/// exist in given size
		/// </summary>
		/// <param name="fontID">FontID</param>
		/// <param name="size">Size</param>
		/// <returns></returns>
		public static Font GetFont(string fontID, int size)
		{
			// Checks if font is loaded in given size
			if (_loadedFonts.ContainsKey(fontID + size))
			{
				return _loadedFonts[fontID + size];
			}
			// checks if Font is Loaded but in different size
			else if (_loadedFonts.Keys.Any(i => i.Contains(fontID)))
			{
				// Gets File location of Font of same id but different size
				string location = _loadedFonts[_loadedFonts.Keys.First(i => i.Contains(fontID))].FileLocation;
				LoadFont(new Font(fontID, location, size));
				// Calls this function with new font loaded and should be returned
				GetFont(fontID, size);
			}

			// if all else fails it will just return the first font
			return _loadedFonts.First().Value;
		}

		public static void LoadSound(Sound sound)
		{
			_loadedSounds.Add(sound);
			Adapter.ReadySound(sound.FileName);
		}

		public static void PlaySound(Sound sound)
		{
			if(!_loadedSounds.Contains(sound))
			{
				LoadSound(sound);
			}

			if(sound.Loop)
			{
				Adapter.LoopSound(sound.FileName, sound.Volume);
			}
			else
			{
				Adapter.PlaySound(sound.FileName, sound.Volume);
			}
		}

		public static bool SoundPlaying(Sound sound)
		{
			return sound != null && Adapter.SoundPlaying(sound.FileName);
		}
	}
}
