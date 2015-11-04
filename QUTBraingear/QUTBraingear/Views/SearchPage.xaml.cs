using System;
using System.Collections.Generic;
using Xamarin.Forms;
using QUTBraingear.Data.ViewModel;
using QUTBraingear.Data;
using QUTBraingear.Data.Models;

namespace QUTBraingear
{
	public partial class SearchPage : BaseView
	{
		public SearchPage()
		{
			InitializeComponent ();
			base.Init ();
			BindingContext = App.Locator.search;
		}

		void OnModuleTap(object sender, EventArgs args) {
			App.Locator.search.ClearSearch ();
			var resultList= (ListView)sender;
			var selectedModule = (resultList.SelectedItem as SearchResult);
			var moduleId = selectedModule.id;
			((MasterDetailPage)Parent).Detail = new ModulePage (moduleId);
		}
	}
}