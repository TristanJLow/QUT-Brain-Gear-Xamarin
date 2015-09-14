using System;

namespace Data
{
	public interface IPageLifeCycleEvents
	{
			void OnAppearing();
			void OnDisappearing();
			void OnLayoutChanged();

	}
}

