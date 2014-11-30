using System;

namespace Thorn.Drs
{
	public class DrsFileInfo : IDrsFileInfo
	{
		#region Constructors

		public DrsFileInfo ()
		{
		}

        #endregion

		#region IDrsFileInfo implementation

		public int FileId {
			get;
			set;
		}

		public int FileDataOffset {
			get;
			set;
		}

		public int FileSize {
			get;
			set;
		}

		#endregion
	}
}

