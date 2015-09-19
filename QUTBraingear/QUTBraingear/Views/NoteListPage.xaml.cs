using System;
using System.Collections.Generic;
using Xamarin.Forms;
using QUTBraingear.Data.ViewModel;

namespace QUTBraingear
{
	public partial class NoteListPage : BaseView
	{
		public NoteListPage ()
		{
			InitializeComponent ();
			base.Init ();
			BindingContext = App.Locator.NoteList;


		}

		protected void ButtonClicked(object sender, EventArgs e)
		{
			Navigation.PushAsync (new NoteDetailsPage ());
		}

	}
}

