using System;

namespace QUTBraingear.Data
{
	public interface IPageLifeCycleEvents
	{
			void OnAppearing();
			void OnDisappearing();
			void OnLayoutChanged();

	}
}

