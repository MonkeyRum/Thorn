using System;

namespace Thorn.Data
{
	/// <summary>
	/// Drs file.
	/// </summary>
	public class DrsFile
	{
		#region Fields

		private string file_name;
		private string file_extension;
		private Int32 id;
		private byte[] file_contents;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="Thorn.Data.DrsFile"/> class.
		/// </summary>
		/// <param name="filename">Filename.</param>
		/// <param name="file_extension">File extension. Must be three characters in length and in the correct order.</param>
		/// <param name="id">Identifier.</param>
		/// <param name="file_contents">File contents.</param>
		public DrsFile(string filename, string file_extension, Int32 id, byte[] file_contents)
		{
			if (file_contents == null)
				throw new ArgumentNullException ("file_contents");
			if (String.IsNullOrEmpty(file_extension))
				throw new ArgumentNullException ("file_extension");
			if (file_extension.Length != 3)
				throw new ArgumentException ("file_extension");
			if (String.IsNullOrEmpty(filename))
				throw new ArgumentNullException ("filename");
			if(id < 0)
				throw new ArgumentException ("id");

			this.file_name = filename;
			this.file_extension = file_extension;
			this.id = id;
			this.file_contents = file_contents;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets the name of the file.
		/// </summary>
		/// <value>The name of the file.</value>
		public string FileName {
			get {
				return file_name;
			}
		}

		/// <summary>
		/// Gets the file extension.
		/// </summary>
		/// <value>The file extension.</value>
		public string FileExtension {
			get {
				return file_extension;
			}
		}

		/// <summary>
		/// Gets the identifier.
		/// </summary>
		/// <value>The identifier.</value>
		public Int32 Id {
			get {
				return id;
			}
		}

		/// <summary>
		/// Gets the file contents.
		/// </summary>
		/// <value>The file contents.</value>
		public byte[] FileContents {
			get {
				return file_contents;
			}
		}

		#endregion
	}
}