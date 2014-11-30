using System;
using System.Collections.Generic;

namespace Thorn.Drs
{
	/// <summary>
	/// DRS (data resource?) archive interface.
	/// </summary>
	public interface IDrs
	{
		IDrsHeader Header { get; set; }
		IList<IDrsTableInfo> TableInfo { get; set; }
		IList<IDrsFileInfo> FileInfo { get; set; }
		IList<byte[]> Files { get; set; }
	}
}

