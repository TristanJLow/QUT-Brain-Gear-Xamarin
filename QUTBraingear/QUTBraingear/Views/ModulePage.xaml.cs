using System;
using System.Collections.Generic;
using Xamarin.Forms;
using QUTBraingear.Data.ViewModel;

namespace QUTBraingear
{
	public partial class ModulePage : BaseView
	{
		public ModulePage ()
		{
			InitializeComponent ();
			base.Init ();
			//BindingContext = App.Locator.NoteList;
		}
	}
}

