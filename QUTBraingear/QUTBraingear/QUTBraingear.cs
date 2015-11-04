using System;
using GalaSoft.MvvmLight.Ioc;
using Xamarin.Forms;
using QUTBraingear.Data.ViewModel;
using QUTBraingear.Data;
using QUTBraingear;
using QUTBrainGear;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;

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

			// The root page of your application
			MainPage = GetMainPage();

		}

		public Page GetMainPage()
		{
			nav = new NavigationService ();
			nav.Configure (ViewModelLocator.LoginPagePageKey, typeof(RootPage));
			SimpleIoc.Default.Register<IMyNavigationService> (()=> nav, true);
			var navPage = new NavigationPage (new RootPage ());
			navPage.BarBackgroundColor = Color.FromHex("003f77");
			nav.Initialize (navPage);
			return navPage;
		}
		protected override void OnStart ()
		{
			QUTBrainGearDB.SyncAsync ();
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

