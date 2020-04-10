using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Adapter
{
	public interface IResourceAdapter
	{
		void LoadFont(Font font);

		void RemoveFont(Font font);

		void ReadySound(string fileLocation);

		void PlaySound(string fileLocation, float volume);

		void LoopSound(string fileLocation, float volume);

		bool SoundPlaying(string fileLocaiton);
	}
}
