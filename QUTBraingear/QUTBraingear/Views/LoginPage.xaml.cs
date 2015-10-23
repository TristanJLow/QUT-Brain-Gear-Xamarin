using System;
using System.Collections.Generic;
using Xamarin.Forms;
using QUTBraingear.Data.ViewModel;
using QUTBraingear.Data;

namespace QUTBraingear
{
	public partial class LoginPage : BaseView
	{
		public LoginPage()
		{
			InitializeComponent();
			base.Init ();
			BindingContext = App.Locator.login;
		}

		void OnLoginTap(object sender, EventArgs args) {
			((MasterDetailPage)Parent).Detail = new OverviewPage();
		}
	}
}
