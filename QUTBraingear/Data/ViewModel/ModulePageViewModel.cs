using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace QUTBraingear.Data.ViewModel
{
	/// <summary>
	/// This class contains properties that the main View can data bind to.
	/// <para>
	/// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
	/// </para>
	/// <para>
	/// You can also use Blend to data bind with the tool's support.
	/// </para>
	/// <para>
	/// See http://www.galasoft.ch/mvvm
	/// </para>
	/// </summary>
	public class ModulePageViewModel : ViewModelBase
	{
		private IMyNavigationService navigationService;
		private Module module;

		/// <summary>
		/// Initializes a new instance of the MainViewModel class.
		/// </summary>
		public ModulePageViewModel(IMyNavigationService navigationService) {
			this.navigationService = navigationService;
			module = new Module (1);
		}

		public string moduleVideo {
			get {
				return module.Video;
			}
		}

		public ObservableCollection<Skills> ModuleSkills {
			get {
				return module.Skills;
			}
		}
	}
}