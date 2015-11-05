using System;
using System.Reflection;
using System.Collections.Generic;
using Xamarin.Forms;
using QUTBraingear.Data.ViewModel;

namespace QUTBraingear
{
	public partial class ProgressMapPage : BaseView
	{
		public ProgressMapPage ()
		{
			InitializeComponent ();
			base.Init ();
			BindingContext = App.Locator.progressMap;
		}

		void OnModuleTap(object sender, EventArgs args) {
			
			((MasterDetailPage)Parent).Detail = new ModulePage ("B8EA42C7-E589-4AFB-A208-9EC85D64DF38");
		}

	}
}