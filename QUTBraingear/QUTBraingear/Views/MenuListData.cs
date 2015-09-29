using System;
using Xamarin.Forms;
using System.Collections.Generic;
using QUTBraingear;

namespace QUTBrainGear
{

	public class MenuListData : List<MenuItem>
	{
		public MenuListData ()
		{
			this.Add (new MenuItem () { 
				Title = "Home", 
				IconSource = "home.png", 
				TargetType = typeof(OverviewPage)
			});

			this.Add (new MenuItem () { 
				Title = "Progress Map", 
				IconSource = "progressmap.png", 
				TargetType = typeof(ProgressMapPage)
			});
					
		}
	}
}