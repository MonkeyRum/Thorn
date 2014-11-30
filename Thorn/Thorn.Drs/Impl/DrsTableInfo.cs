using System;

namespace Thorn.Drs
{
	public class DrsTableInfo : IDrsTableInfo
	{
		#region Constructors

		public DrsTableInfo ()
		{
		}

		#endregion

		#region IDrsTableInfo implementation

		public byte FileType {
			get;
			set;
		}

		public byte[] FileExtension {
			get;
			set;
		}

		public int FileInfoOffset {
			get;
			set;
		}

		public int NumFiles {
			get;
			set;
		}

		#endregion
	}
}

