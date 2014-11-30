using System;
using System.Collections.Generic;

namespace Thorn.Drs
{
	public class Drs : IDrs
	{
		#region Constructors

		public Drs ()
		{
			// Nothing exciting yet
		}

		#endregion

		#region IDrs implementation

		public IDrsHeader Header {
			get;
			set;
		}

		public IList<IDrsTableInfo> TableInfo {
			get;
			set;
		}

		public IList<IDrsFileInfo> FileInfo {
			get;
			set;
		}

		public IList<byte[]> Files {
			get;
			set;
		}

		#endregion
	}
}

