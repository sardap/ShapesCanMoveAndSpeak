using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibary
{
	/// <summary>
	/// Stores All nessracy Infomation for API to use fonts
	/// </summary>
	public class Font
	{
		/// <summary>
		/// Font id used to access font form resource manager
		/// </summary>
		private string _id;
		private string _fileLocation;
		private int _size;
	
		public Font(string id, string location, int size)
		{
			_id = id + size;
			_size = size;
			_fileLocation = location;
		}

		public string ID
		{
			get
			{
				return _id;
			}
		}

		public string FileLocation
		{ 
			get
			{
				return _fileLocation;
			}
		}

		public int Size
		{
			get
			{
				return _size;
			}
		}
	}
}
