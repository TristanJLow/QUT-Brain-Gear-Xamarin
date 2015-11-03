using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Microsoft.WindowsAzure.MobileServices;

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
		public ICommand AddCommentsCommand { get; private set;}
		private Module module { get; set; }
		public string AddComment { get; set; }

		/// <summary>
		/// Initializes a new instance of the MainViewModel class.
		/// </summary>
		public ModulePageViewModel(IMyNavigationService navigationService) {
			this.navigationService = navigationService;

			AddCommentsCommand = new Command (() => {
				var newComment = new Comment(ModuleId, AddComment);
				QUTBrainGearDB.InsertOrUpdateComments(newComment);
				module.moduleComments.Add(newComment);
				AddComment = null;
				RaisePropertyChanged (() => ModuleComments);
				RaisePropertyChanged (() => AddComment);
				RaisePropertyChanged (() => ListHeight);
			});
		}

		public async void UpdatePageContent (string selectedModule) {
			module = await QUTBrainGearDB.GetModule(selectedModule).ConfigureAwait(false);
			RaisePropertyChanged (() => ModuleSkills);
			RaisePropertyChanged (() => ModuleVideo);
			module.moduleComments = new ObservableCollection<Comment>(await QUTBrainGearDB.GetModuleComments(ModuleId).ConfigureAwait(false));
			RaisePropertyChanged (() => ModuleComments);
			RaisePropertyChanged (() => ListHeight);
		}

		public string ModuleId {
			get {
				return module.id;
			}
		}

		public string ModuleVideo {
			get {
				if (module == null) {
					return "";
				} else {
					return module.videoURL;
				}
			}
		}

		public ObservableCollection<Skills> ModuleSkills {
			get {
				if (module == null) {
					return null;
				} else {
					return module.moduleSkills;
				}
			}
		}

		public ObservableCollection<Comment> ModuleComments {
			get {
				if (module == null) {
					return null;
				} else {
					return module.moduleComments;
				}
			}
		}

		public int ListHeight {
			get {
				var objects = 0;
				if (module != null) {
					objects = module.moduleComments.Count;
				}
				var height = (objects * 25) + 40;
				return height;
			}
		}
	}
}