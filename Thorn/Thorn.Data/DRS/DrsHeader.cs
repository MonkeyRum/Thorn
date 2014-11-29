using System;

namespace Thorn.Data
{
	public struct DrsHeader
	{
		const int COPYRIGHT_AOE_LENGTH = 40;
		const int COPYRIGHT_SWGB_LENGTH = 60;
		const int VERSION_LENGTH = 4;
		const int FTYPE_LENGTH = 12;

		byte[] copyright;
		byte[] version;
		byte[] ftype;
		Int32 table_count;
		Int32 file_offest;
	}
}

