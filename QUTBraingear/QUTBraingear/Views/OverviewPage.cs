using System;
using System.Collections.Generic;
using Xamarin.Forms;
using QUTBraingear.Data.ViewModel;
using QUTBraingear.Data;

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
			/*var selectedModule = (Module)sender;
			selectedModule.moduleID;*/
			((MasterDetailPage)Parent).Detail = new ModulePage ();
		}
	}

}

