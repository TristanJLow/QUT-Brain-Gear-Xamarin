using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace QUTBrainGear
{
	public class MenuPage : ContentPage
	{
		public ListView Menu { get; set; }

		public MenuPage ()
		{
			Icon = "settings.png";
			Title = "menu";
			BackgroundColor = Color.FromHex ("#003f77");

			Menu = new MenuListView ();

			var menuLabel = new ContentView {
				Padding = new Thickness (10, 15, 0, 15),
				VerticalOptions = LayoutOptions.Center,
				Content = new Label {
					TextColor = Color.FromHex ("#ffffff"),
					FontSize = 15,
					Text = "USERNAME \nEmail ",
				}
			};

			var layout = new StackLayout { 
				Spacing = 0, 
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			layout.Children.Add (menuLabel);
			layout.Children.Add (Menu);

			Content = layout;
		}
	}
}