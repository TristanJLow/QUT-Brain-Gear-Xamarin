using System;
using System.Collections.Generic;
using Xamarin.Forms;
using QUTBraingear.Data.ViewModel;
using XLabs.Forms.Controls;

namespace QUTBraingear
{
	public partial class QuizPage : BaseView
	{
		public QuizPage ()
		{
			InitializeComponent ();
			base.Init ();			               
		}

		void OnOkTap(object sender, EventArgs args)
		{
			CheckBox answer11 = this.Answer11;
			CheckBox answer12 = this.Answer12;
			CheckBox answer21 = this.Answer21;
			CheckBox answer22 = this.Answer22;
			CheckBox answer31 = this.Answer31;
			CheckBox answer32 = this.Answer32;
			CheckBox answer41 = this.Answer41;
			CheckBox answer42 = this.Answer42;
			if (!(answer12.Checked && !answer12.Checked && !answer21.Checked && answer22.Checked && !answer31.Checked && answer32.Checked && answer41.Checked && answer42.Checked)) {
				DisplayAlert ("Alert", "Oops! That wasn't quite right. Give it another go.", "OK");           
			}
			else {
				DisplayAlert("Alert", "Well Done, you passed!", "OK");
			}

		}

		void OnHomeTap(object sender, EventArgs args)
		{

			((MasterDetailPage)Parent).Detail = new OverviewPage();            
		}

	}
}
