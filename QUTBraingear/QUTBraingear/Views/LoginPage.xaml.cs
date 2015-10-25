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
			if (this.Username.Text == "admin" && this.Password.Text == "admin") {
				((MasterDetailPage)Parent).Detail = new OverviewPage ();
			} else {
				DisplayAlert ("Alert", "Invalid username or password", "OK");
			}
		}
	}
}
