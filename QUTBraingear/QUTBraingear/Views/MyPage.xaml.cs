using System;
using System.Collections.Generic;
using QUTBraingear.Data.ViewModel;
using Xamarin.Forms;
using QUTBraingear.Data;
using Microsoft.Practices.ServiceLocation;

namespace QUTBraingear
{

	public partial class MyPage : BaseView
	{
		public MyPage ()
		{

			InitializeComponent ();
			base.Init ();
			//BindingContext = App.Locator.MyPage;

			/*var upcomingQA = new List<QA> ();
			var firstQA = new QA ("Xamarin Dev", DateTime.Now.ToString ());
			var secondQa = new QA ("Not Xamarin", DateTime.Now.ToString ());
			upcomingQA.Add(firstQA);
			upcomingQA.Add(secondQa);
			listview_QAUpcoming.ItemsSource = upcomingQA;

			var skillList = new List<Skills> ();
			var firstSkill = new Skills ("Xamarin", "10");
			var secondSkill = new Skills ("Design", "-10");
			skillList.Add (firstSkill);
			skillList.Add (secondSkill);
			listview_pointProgress.ItemsSource = skillList;*/
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			var vm = ServiceLocator.Current.GetInstance<MyPageViewModel> ();
		}
	}
}

