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
	public class OverviewPageViewModel : ViewModelBase
	{
		private IMyNavigationService navigationService;
		private List<QA> qaList = new List<QA>();
		private List<Skills> skillList = new List<Skills>();
		private ObservableCollection<Module> recentVideos = new ObservableCollection<Module> ();

		public List<QA> QAList {
			get { return qaList; }
			set {
				if (value != null && value != qaList) {
					qaList = value;
				}
			}
		}

		public ObservableCollection<Module> RecentVideos {
			get { return recentVideos; }
			set {
				if (value != null && value != recentVideos) {
					recentVideos = value;
				}
			}
		}

		public List<Skills> SkillList {
			get { return skillList; }
			set {
				if (value != null && value != skillList) {
					skillList = value;
				}
			}
		}
			
		/// <summary>
		/// Initializes a new instance of the MainViewModel class.
		/// </summary>
		public OverviewPageViewModel(IMyNavigationService navigationService)
		{
			this.navigationService = navigationService;
			QUTBrainGearDB db = new QUTBrainGearDB ();
			db.InsertOrUpdateQA (new QA ("Xamarin", DateTime.Now.ToString ()));

			QAList = db.GetAllQA ();

			db.InsertOrUpdateSkill (new Skills ("Xamarin", "20"));
			db.InsertOrUpdateSkill (new Skills ("C#", "10"));
			skillList = db.GetAllSkills ();

			var databaseModules = new ObservableCollection<Module>(db.GetAllModules ());
			recentVideos = databaseModules;
			if (recentVideos.Count < 3) {
				Module recent1 = new Module ();
				Module recent2 = new Module ();
				Module recent3 = new Module ();
				recent3.videoURL = "hon3";
				recent2.videoURL = "hon2";
				RecentVideos.Add (recent1);
				db.InsertOrUpdateModules (recent1);
				RecentVideos.Add (recent2);
				db.InsertOrUpdateModules (recent2);
				RecentVideos.Add (recent3);
				db.InsertOrUpdateModules (recent3);
			};
		}

	}
}