using System;
using System.Reflection;
using System.Collections.Generic;
using Xamarin.Forms;
using QUTBraingear.Data.ViewModel;

namespace QUTBraingear
{
	public partial class ProgressMapPage : BaseView
	{
		public ProgressMapPage ()
		{
			InitializeComponent ();
			base.Init ();
			BindingContext = App.Locator.progressMap;
		}


	}
}