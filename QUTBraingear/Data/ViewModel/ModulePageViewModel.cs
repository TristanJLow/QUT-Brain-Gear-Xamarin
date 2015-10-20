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
		public ICommand AddCommentsCommand { get; private set;}
		private Module module;
		public string AddComment { get; set; }
		private QUTBrainGearDB database = new QUTBrainGearDB();

		/// <summary>
		/// Initializes a new instance of the MainViewModel class.
		/// </summary>
		public ModulePageViewModel(IMyNavigationService navigationService) {
			this.navigationService = navigationService;

			AddCommentsCommand = new Command (() => {
				var newComment = new Comment(ModuleId, AddComment);
				database.InsertOrUpdateComments(newComment);
				module.moduleComments.Add(newComment);
				AddComment = null;
				RaisePropertyChanged (() => AddComment);
				RaisePropertyChanged (() => ListHeight);
			});
		}
		public void UpdatePageContent (int selectedModule) {
			module = database.GetModule(selectedModule);

			ObservableCollection<Comment> storedComments = new ObservableCollection<Comment>(database.GetModuleComments(ModuleId));
			module.moduleComments = storedComments;
		}

		public int ModuleId {
			get {
				return module.moduleID;
			}
		}

		public string ModuleVideo {
			get {
				return module.videoURL;
			}
		}

		public ObservableCollection<Skills> ModuleSkills {
			get {
				return module.moduleSkills;
			}
		}

		public ObservableCollection<Comment> ModuleComments {
			get {
				return module.moduleComments;
			}
		}

		public int ListHeight {
			get {
				var objects = module.moduleComments.Count;
				var height = (objects * 25) + 40;
				return height;
			}
		}
	}
}