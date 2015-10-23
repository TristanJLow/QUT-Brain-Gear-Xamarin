using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

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
		private QUTBrainGearDB db = new QUTBrainGearDB ();

		private ObservableCollection<Module> _recentVideos;
		private ObservableCollection<QA> _qaList;
		private ObservableCollection<Skills> _skillList;

		public ObservableCollection<QA> qaList {
			get { return _qaList; }
			set { if (_qaList != value) {
					_qaList = value;
				}
			}
		}

		public ObservableCollection<Skills> skillList {
			get { return _skillList; }
			set { if (_skillList != value) {
					_skillList = value;
				}
			}
		}

		public ObservableCollection<Module> recentVideos {
			get { return _recentVideos; }
			set { if (_recentVideos != value) {
					_recentVideos = value;
				}
			}
		}
			
		public async void QAList () {
			this.qaList = await db.GetAllQA ();
			RaisePropertyChanged (() => qaList);
		}

		public async void SkillList () {
			this.skillList = await db.GetAllSkills ();
			RaisePropertyChanged (() => skillList);
		}

		public async void RecentVideos () {
			this.recentVideos = await db.GetAllModules ();
			RaisePropertyChanged (() => recentVideos);
		}
			
		/// <summary>
		/// Initializes a new instance of the MainViewModel class.
		/// </summary>
		public OverviewPageViewModel(IMyNavigationService navigationService)
		{
			this.navigationService = navigationService;
			QAList ();
			SkillList ();
			RecentVideos ();
		}

	}
}