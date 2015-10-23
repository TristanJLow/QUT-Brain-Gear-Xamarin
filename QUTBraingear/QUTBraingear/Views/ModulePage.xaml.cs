using System;
using System.Collections.Generic;
using Xamarin.Forms;
using QUTBraingear.Data.ViewModel;

namespace QUTBraingear
{
	public partial class ModulePage : BaseView
	{
		public ModulePage (string id = "0")
		{
			InitializeComponent ();
			base.Init ();
			App.Locator.module.UpdatePageContent (id);
			BindingContext = App.Locator.module;
		}

		void OnWikiTap(object sender, EventArgs args) {
			((MasterDetailPage)Parent).Detail = new WikiPage();
		}
	}
}

