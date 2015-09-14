using System;
using System.Collections.Generic;
using Data.ViewModel;
using Xamarin.Forms;

namespace QUTBraingear
{
	public partial class MyPage : BaseView
	{
		public MyPage ()
		{
			InitializeComponent ();
			/*base.Init ();
			BindingContext = App.Locator.MyPage;*/

			var upcomingQA = new List<QA> ();
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
			listview_pointProgress.ItemsSource = skillList;
		}
	}
}

