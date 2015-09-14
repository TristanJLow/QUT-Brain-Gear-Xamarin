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
		private string qaTitle;

		public string QaTitle
		{
			get { return qaTitle; }
			set { qaTitle = value; }
		}

		private string qaOccurs;

		public string QaOccurs
		{
			get { return qaOccurs; }
			set { qaOccurs = value; }	
		}



		public MyPageViewModel (IMyNavigationService navigationService)
		{
			
		}
	}
}

