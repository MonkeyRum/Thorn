using System;

namespace Thorn.Drs
{
	public interface IDrsTableInfo
	{
		/// <summary>
		/// Gets or sets the file fype. 0x61 for bin otherwise 0x20.
		/// </summary>
		/// <value>The file fype.</value>
		byte FileType { get; set; }

		/// <summary>
		/// Gets or sets the file extension, stored in reverse for whatever reason.
		/// </summary>
		/// <value>The file extension.</value>
		/// <example>
		/// slp, bin, wav
		/// but stored
		/// pls, nib, vaw
		/// </example>
		byte[] FileExtension { get; set; } 		// char in C/++, 3

		/// <summary>
		/// Gets or sets the file info offset from the beginning of the DRS archive.
		/// </summary>
		/// <value>The file info offset.</value>
		Int32 FileInfoOffset { get; set; }

		/// <summary>
		/// Gets or sets the number files this header is responsible for.
		/// </summary>
		/// <value>The number files.</value>
		/// <description>
		/// Number of IDrsFileInfos that begin at the FileInfoOffset.
		/// </description>
		Int32 NumFiles{ get; set; }
	}
}

