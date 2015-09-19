using System;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using Xamarin.Forms;
using QUTBraingear.Data.ViewModel;
using Microsoft.Practices.ServiceLocation;

namespace QUTBraingear.Data
{
	public class MyPageViewModel : ViewModelBase
	{
		private IMyNavigationService navigationService;

		private string qaTitle;

		public string QaTitle
		{
			get { return qaTitle; }
			set { qaTitle = value;
				RaisePropertyChanged(() => QaTitle); }
		}

		private string qaOccurs;

		public string QaOccurs
		{
			get { return qaOccurs; }
			set { qaOccurs = value; 
				RaisePropertyChanged(() => QaOccurs);}	
		}



		public MyPageViewModel (IMyNavigationService navigationService)
		{
			QaTitle = "xmaarin";
			QaOccurs = "12/1/1";
			this.navigationService = navigationService;
			/*var mypageVM = ServiceLocator.Current.GetInstance<MyPageViewModel>();
			mypageVM.qaTitle = "Xamarin ex";
			mypageVM.qaOccurs = DateTime.Now.ToString ();*/
		

		}

		/*public void OnAppearing(){
			RaisePropertyChanged (() => qaTitle);
		}*/
	}
}

