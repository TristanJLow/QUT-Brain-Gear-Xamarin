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

		void introToXamTap(object sender, EventArgs args) {
			
			((MasterDetailPage)Parent).Detail = new ModulePage ("B8EA42C7-E589-4AFB-A208-9EC85D64DF38");
		}

		void cSharp101Tap(object sender, EventArgs args) {

			((MasterDetailPage)Parent).Detail = new ModulePage ("0C8788AE-F61D-4216-9C1A-5189B9887715");
		}

		void agileTap(object sender, EventArgs args) {

			((MasterDetailPage)Parent).Detail = new ModulePage ("E08013D4-1411-4865-A1EA-BD864EFFB35E");
		}

	}
}