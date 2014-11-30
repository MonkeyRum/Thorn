using System;
using Gtk;
using Thorn.Control;
using Thorn.Drs;

public partial class MainWindow: Gtk.Window
{
	private MainPresenter presenter;

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		presenter = new MainPresenter();
		Build ();

		CellRendererText renderer = new CellRendererText ();

		treeview1.AppendColumn ("ID", renderer, new TreeCellDataFunc(RenderArtistName));
		ListStore fileListStore = new Gtk.ListStore (typeof (IDrsFileInfo));



		treeview1.Model = fileListStore;
	}

	//http://stackoverflow.com/questions/9787028/gtk-treeview-hierarchical-data-display
	private void RenderArtistName(TreeViewColumn column, CellRenderer cell, TreeModel model, TreeIter iter)
	{
		IDrsFileInfo s = model.GetValue(iter,0) as IDrsFileInfo;
		(cell as CellRendererText).Text = s.FileId.ToString();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnOpenActionActivated (object sender, EventArgs e)
	{
		using (Gtk.FileChooserDialog filechooser =
			new Gtk.FileChooserDialog("Choose the DRS Archive to open",
				this,
				FileChooserAction.Open,
				"Cancel",ResponseType.Cancel,
				"Open",ResponseType.Accept))
		{
			if (filechooser.Run () == (int)ResponseType.Accept) {
				presenter.LoadDrsFile (filechooser.Filename);
			}

			filechooser.Destroy ();
		}

		foreach (var drsFileInfo in presenter.DRS.FileInfo) {

			((ListStore)treeview1.Model).AppendValues (drsFileInfo);
		}
	}

	protected void OnTreeview1CursorChanged (object sender, EventArgs e)
	{
		TreeSelection selection = (sender as TreeView).Selection;
		TreeModel model;
		TreeIter iter;

		if (selection.GetSelected (out model, out iter)) {

			var val = model.GetValue (iter, 0);
		}
	}
}
