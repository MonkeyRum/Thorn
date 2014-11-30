using System;

namespace Thorn.Drs
{
	public class DrsHeader : IDrsHeader
	{
		#region Constructors

		public DrsHeader ()
		{

		}

		#endregion

		#region IDrsHeader implementation

		public byte[] Copyright {
			get;
			set;
		}

		public byte[] Version {
			get;
			set;
		}

		public byte[] FType {
			get;
			set;
		}

		public int TableCount {
			get;
			set;
		}

		public int FileOffset {
			get;
			set;
		}

		#endregion
	}
}

