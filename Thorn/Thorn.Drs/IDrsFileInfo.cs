using System;

namespace Thorn.Drs
{
	public interface IDrsFileInfo
	{
		/// <summary>
		/// Gets or sets the file identifier (also used as the file's name).
		/// </summary>
		/// <value>The file identifier.</value>
		Int32 FileId { get; set; }

		/// <summary>
		/// Gets or sets the file data offset from the beginning of the DRS archive.
		/// </summary>
		/// <value>The file data offset.</value>
		Int32 FileDataOffset { get; set; }

		/// <summary>
		/// Gets or sets the size of the file in bytes.
		/// </summary>
		/// <value>The size of the file.</value>
		Int32 FileSize { get; set; }
	}
}

