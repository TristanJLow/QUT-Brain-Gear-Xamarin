using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace QUTBraingear
{
	public partial class MyPage : ContentPage
	{
		public MyPage ()
		{
			InitializeComponent ();
			var noteList = new List<QA> ();
			var firstQA = new QA ("Xamarin Dev", DateTime.Now.ToString ());
			var secondQa = new QA ("Not Xamarin", DateTime.Now.ToString ());
			noteList.Add(firstQA);
			noteList.Add(secondQa);
			listview_QAUpcoming.ItemsSource = noteList;
		}
	}
}

