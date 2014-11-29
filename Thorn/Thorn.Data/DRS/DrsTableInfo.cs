using System;

namespace Thorn.Data
{
	public struct DrsTableInfo
	{
		const int FILE_EXT_LENGTH = 3;

		byte file_type;
		byte[] file_ext;
		Int32 table_offset;
		Int32 number_of_tiles;
	}
}

