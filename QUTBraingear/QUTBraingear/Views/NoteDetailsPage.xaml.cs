using System;
using System.Collections.Generic;

using Xamarin.Forms;
using QUTBraingear.Data.ViewModel;
using QUTBraingear.Data;

namespace QUTBraingear
{
	public partial class NoteDetailsPage : BaseView
	{
		public NoteDetailsPage ()
		{
			BindingContext = App.Locator.NoteDetail;
			InitializeComponent ();
			base.Init ();
			Title = "Details";
		}
	}
}

