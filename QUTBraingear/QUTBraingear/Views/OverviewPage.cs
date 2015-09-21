using System;
using System.Collections.Generic;
using Xamarin.Forms;
using QUTBraingear.Data.ViewModel;

namespace QUTBraingear
{
	public partial class OverviewPage : BaseView
	{
		public OverviewPage ()
		{
			InitializeComponent ();
			base.Init ();
			BindingContext = App.Locator.NoteList;


		}

		void OnModuleTap(object sender, EventArgs args) {
				Navigation.PushAsync(new ModulePage());
		}
	
	}

}

