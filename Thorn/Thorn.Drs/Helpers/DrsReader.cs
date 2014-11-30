using System;
using System.IO;
using System.Collections.Generic;

namespace Thorn.Drs.Helpers
{
	public static class DrsReader
	{
		/// <summary>
		/// Reads the DRS archive from disk.
		/// </summary>
		/// <returns>The drs or null.</returns>
		/// <param name="filename">Full filename including path.</param>
		public static IDrs ReadDrs (string filename)
		{
			// Need some sanity checks and blahdyyea
			// Split into smaller chunkies...

			IDrs drs = null;

			try {
				drs = new Drs();

				using (BinaryReader b = new BinaryReader (File.Open (filename, FileMode.Open))) {

					ReadDrsHeader (drs, b);
					var totalNumFiles = ReadDrsTableInfo (drs, b);
					ReadDrsFileInfo (drs, b, totalNumFiles);
					ReadDrsFileContents(drs, b);
				}
			}
			catch {

				// Failed
				drs = null;
			}

			return drs;
		}

		static void ReadDrsHeader (IDrs drs, BinaryReader b)
		{
			var header = new DrsHeader();
			drs.Header = header;

			// Magic numbers... mhmmmmm...
			header.Copyright = b.ReadBytes (40);
			header.Version = b.ReadBytes (4);
			header.FType = b.ReadBytes (12);
			header.TableCount = b.ReadInt32 ();
			header.FileOffset = b.ReadInt32 ();
		}

		static int ReadDrsTableInfo (IDrs drs, BinaryReader b)
		{
			drs.TableInfo = new List<IDrsTableInfo>(drs.Header.TableCount);

			int totalNumFiles = 0;

			for (int i = 0; i < drs.Header.TableCount; ++i) {

				var tableInfo = new DrsTableInfo ();
				tableInfo.FileType = b.ReadByte ();
				tableInfo.FileExtension = b.ReadBytes (3);
				tableInfo.FileInfoOffset = b.ReadInt32 ();
				tableInfo.NumFiles = b.ReadInt32 ();
				totalNumFiles += tableInfo.NumFiles;
				drs.TableInfo.Add (tableInfo);
			}

			return totalNumFiles;
		}

		static void ReadDrsFileInfo (IDrs drs, BinaryReader b, int totalNumFiles)
		{
			drs.FileInfo = new List<IDrsFileInfo>(totalNumFiles);

			foreach (IDrsTableInfo table in drs.TableInfo) {

				b.BaseStream.Seek (table.FileInfoOffset, SeekOrigin.Begin);

				for (int j = 0; j < table.NumFiles; ++j) {

					var fileInfo = new DrsFileInfo ();
					fileInfo.FileId = b.ReadInt32 ();
					fileInfo.FileDataOffset = b.ReadInt32 ();
					fileInfo.FileSize = b.ReadInt32 ();
					drs.FileInfo.Add (fileInfo);
				}
			}
		}

		private static void ReadDrsFileContents(IDrs drs, BinaryReader b)
		{
			drs.Files = new List<byte[]> (drs.FileInfo.Count);

			foreach (var fileInfo in drs.FileInfo) {

				b.BaseStream.Seek (fileInfo.FileDataOffset, SeekOrigin.Begin);

				byte[] fileContents = b.ReadBytes (fileInfo.FileSize);
				drs.Files.Add(fileContents);
			}
		}
	}
}

