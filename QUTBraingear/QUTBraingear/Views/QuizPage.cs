using System;
using System.Collections.Generic;
using Xamarin.Forms;
using QUTBraingear.Data.ViewModel;

namespace QUTBraingear
{
	public partial class QuizPage : BaseView
	{
		public QuizPage ()
		{
			InitializeComponent ();
			base.Init ();
			BindingContext = App.Locator.module;
		}
			
	}
}
