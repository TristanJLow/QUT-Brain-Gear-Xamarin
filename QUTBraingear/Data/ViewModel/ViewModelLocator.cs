/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:NoteTaker1.Data"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace QUTBraingear.Data.ViewModel
{
	/// <summary>
	/// This class contains static references to all the view models in the
	/// application and provides an entry point for the bindings.
	/// </summary>
	public class ViewModelLocator
	{
		public const string ModulePagePageKey = "ModulePage";
		public const string OverviewPagePageKey = "OverviewPage";
		public const string ProgressMapPagePageKey = "ProgressMapPage";
		public const string LoginPagePageKey = "LoginPage";
		public const string SearchPagePageKey = "SearchPage";

		/// <summary>
		/// Initializes a new instance of the ViewModelLocator class.
		/// </summary>
		public ViewModelLocator()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			////if (ViewModelBase.IsInDesignModeStatic)
			////{
			////    // Create design time view services and models
			////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
			////}
			////else
			////{
			////    // Create run time view services and models
			////    SimpleIoc.Default.Register<IDataService, DataService>();
			////}

			SimpleIoc.Default.Register<OverviewPageViewModel>(() => 
				{
					return new OverviewPageViewModel(
						SimpleIoc.Default.GetInstance<IMyNavigationService>()
					);
				});

			SimpleIoc.Default.Register<ModulePageViewModel>(() => 
				{
					return new ModulePageViewModel(
						SimpleIoc.Default.GetInstance<IMyNavigationService>()
					);
				});

			SimpleIoc.Default.Register<ProgressMapPageViewModel>(() => 
				{
					return new ProgressMapPageViewModel(
						SimpleIoc.Default.GetInstance<IMyNavigationService>()
					);
				});

			SimpleIoc.Default.Register<LoginPageViewModel>(() => 
				{
					return new LoginPageViewModel(
						SimpleIoc.Default.GetInstance<IMyNavigationService>()
					);
				});

			SimpleIoc.Default.Register<SearchPageViewModel>(() =>
				{
					return new SearchPageViewModel(
						SimpleIoc.Default.GetInstance<IMyNavigationService>()
					);
				});
		}

		public OverviewPageViewModel overview
		{
			get
			{
				return ServiceLocator.Current.GetInstance<OverviewPageViewModel>();
			}
		}

		public ModulePageViewModel module
		{
			get
			{
				return ServiceLocator.Current.GetInstance<ModulePageViewModel>();
			}
		}

		public ProgressMapPageViewModel progressMap
		{
			get
			{
				return ServiceLocator.Current.GetInstance<ProgressMapPageViewModel>();
			}
		}

		public LoginPageViewModel login
		{
			get
			{
				return ServiceLocator.Current.GetInstance<LoginPageViewModel>();
			}
		}

		public SearchPageViewModel search
		{
			get
			{
				return ServiceLocator.Current.GetInstance<SearchPageViewModel>();
			}
		}

		public static void Cleanup()
		{
			// TODO Clear the ViewModels
		}
	}
}