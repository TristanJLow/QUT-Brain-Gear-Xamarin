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
			BindingContext = App.Locator.overview;
		}

		void OnModuleTap(object sender, EventArgs args) {
			//var imageSender = (Image)sender;

			//label_text1.Text = imageSender.Id.ToString();
			//Navigation.PushAsync(new ModulePage());
			((MasterDetailPage)Parent).Detail = new ModulePage ();

		}

		void Recent1(object sender, EventArgs args) {
			//var imageSender = (Image)sender;

			//label_text1.Text = imageSender.Id.ToString();
			((MasterDetailPage)Parent).Detail = new ModulePage ();

			//Navigation.PushAsync(new ModulePage());
		}

		void Recent2(object sender, EventArgs args) {
			//var imageSender = (Image)sender;

			//label_text1.Text = imageSender.Id.ToString();
			//Navigation.PushAsync(new ModulePage());
			((MasterDetailPage)Parent).Detail = new ModulePage ();

		}

		void Recent3(object sender, EventArgs args) {
			//var imageSender = (Image)sender;

			//label_text1.Text = imageSender.Id.ToString();
			//Navigation.PushAsync(new ModulePage());
			((MasterDetailPage)Parent).Detail = new ModulePage ();

		}
	
	}

}

