using System;
using Thorn.Drs.Helpers;
using Thorn.Drs;

namespace Thorn.Control
{
	public class MainPresenter
	{
		public IDrs DRS {
			get;
			private set;
		}

		public MainPresenter ()
		{
		}

		public bool LoadDrsFile (string filename)
		{
			bool retval = false;

			try {
				IDrs drs = DrsReader.ReadDrs (filename);

				if(drs != null) {
					this.DRS = drs;
					retval = true;
				}
			}
			catch {
				retval = false;
			}

			return retval;
		}
	}
}

