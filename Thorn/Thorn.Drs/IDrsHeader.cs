using System;

namespace Thorn.Drs
{
	public interface IDrsHeader
	{
		/// <summary>
		/// Gets or sets the copyright string.
		/// </summary>
		/// <value>The copyright.</value>
		/// <example>
		/// Copyright (c) 1997 Ensemble Studios
		/// </example>
		byte[] Copyright { get; set; }		// 40 AOE 60 SWGB

		/// <summary>
		/// Gets or sets the version.
		/// </summary>
		/// <value>The version.</value>
		/// <example>
		/// 1.00
		/// </example>
		byte[] Version { get; set; }		// 4

		/// <summary>
		/// Gets or sets the type of the F.
		/// </summary>
		/// <value>The type of the file.</value>
		/// <example>
		/// tribe
		/// </example>
		byte[] FType { get; set; }			// 12

		/// <summary>
		/// Gets or sets the number of <see cref="IDrsTableInfo"/> tables (one for each file extension).
		/// </summary>
		/// <value>The table count.</value>
		Int32 TableCount { get; set; }

		/// <summary>
		/// Gets or sets the file offset from the beginning of the DRS archive to the first real file.
		/// </summary>
		/// <value>The file offset.</value>
		Int32 FileOffset { get; set; }
	}
}

