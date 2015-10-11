using System;
using Xamarin.Forms;
using System.Linq;
using QUTBraingear;

namespace QUTBrainGear
{
	public class RootPage : MasterDetailPage
	{
		MenuPage menuPage;

		public RootPage ()
		{
			menuPage = new MenuPage ();

			menuPage.Menu.ItemSelected += (sender, e) => NavigateTo (e.SelectedItem as MenuItem);
			var navPage = new OverviewPage ();

			Master = menuPage;
			Detail = navPage;
		}

		void NavigateTo (MenuItem menu)
		{
			if (menu == null)
				return;
			
			Page displayPage = (Page)Activator.CreateInstance (menu.TargetType);

			Detail = displayPage;

			menuPage.Menu.SelectedItem = null;
			IsPresented = false;
		}
	}
}