using System;
using System.Collections.Generic;
using Xamarin.Forms;
using QUTBraingear.Data.ViewModel;
using QUTBrainGear;

namespace QUTBraingear
{
	public partial class OverviewPage : BaseView
	{
		public OverviewPage ()
		{
			InitializeComponent ();
			base.Init ();
			BindingContext = App.Locator.overview;
		}

		void OnModuleTap(object sender, EventArgs args) {
			((MasterDetailPage)Parent).Detail = new ModulePage ();
		}
	
	}

}

