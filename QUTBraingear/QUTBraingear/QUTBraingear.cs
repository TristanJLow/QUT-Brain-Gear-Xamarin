using System;

using Xamarin.Forms;
using GalaSoft.MvvmLight.Ioc;
using QUTBraingear.Data;
using QUTBraingear.Data.ViewModel;

namespace QUTBraingear
{
	public class App : Application
	{
		private static ViewModelLocator _locator;
		private static NavigationService nav;
		public static ViewModelLocator Locator
		{
			get
			{
				return _locator ?? (_locator = new ViewModelLocator());
			}
		}

		public App ()
		{
			
			MainPage = getMainPage ();
			//MainPage =new MyPage ();
			// The root page of your application
			/*MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							XAlign = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms!"
						}
					}
				}
			};*/
		}

		public Page getMainPage()
		{
			nav = new NavigationService ();
			nav.Configure (ViewModelLocator.MyPagePageKey, typeof(MyPage));
			//nav.Configure (ViewModelLocator.NoteDetailPageKey, typeof(NoteDetailsPage));
			SimpleIoc.Default.Register<IMyNavigationService> (()=> nav, true);
			var navPage = new NavigationPage (new MyPage ());
			nav.Initialize (navPage);
			return navPage;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

