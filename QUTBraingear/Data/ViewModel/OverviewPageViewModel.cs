﻿using GalaSoft.MvvmLight;
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
		private List<QA>/*ObservableCollection<QA>*/ qaList = new List<QA>();
		private List<Skills> skillList = new List<Skills>();
		private List<String> recentVideos = new List<String> ();

		private String recentVideo1;
		private String recentVideo2;
		private String recentVideo3;

		public List<QA> QAList {
			get { return qaList; }
			set {
				if (value != null && value != qaList) {
					qaList = value;
				}
			}
		}

		public List<String> RecentVideos {
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

		public string FirstVideo {
			get { return recentVideo1; }
			set {
				if (value != null && value != recentVideo1) {
					recentVideo1 = value;
				}
			}
		}

		public string SecondVideo {
			get { return recentVideo2; }
			set {
				if (value != null && value != recentVideo2) {
					recentVideo2 = value;
				}
			}
		}


		public string ThirdVideo {
			get { return recentVideo3; }
			set {
				if (value != null && value != recentVideo3) {
					recentVideo3 = value;
				}
			}
		}
		/// <summary>
		/// Initializes a new instance of the MainViewModel class.
		/// </summary>
		public OverviewPageViewModel(IMyNavigationService navigationService)
		{
			this.navigationService = navigationService;
			QADatabase qaDatabase = new QADatabase ();	
			qaDatabase.InsertOrUpdateQA (new QA ("Xamarin", DateTime.Now.ToString ()));

			QAList = qaDatabase.GetAll ();

			SkillsDatabase skillsDatabase = new SkillsDatabase ();
			skillsDatabase.InsertOrUpdateSkill (new Skills ("Xamarin", "20"));
			skillsDatabase.InsertOrUpdateSkill (new Skills ("C#", "10"));
			skillList = skillsDatabase.GetAll ();

			RecentVideos.Add ("Testing 1");
			RecentVideos.Add ("Testing 2");
			RecentVideos.Add ("Testing 3");
			FirstVideo = RecentVideos [0];
			SecondVideo = RecentVideos [1];
			ThirdVideo = RecentVideos [2];
			//QAList.Add (new QA ("Xamarin Development", "LIVE"));
			/*SkillList.Add (new Skills ("Xamarin", "20"));
			SkillList.Add (new Skills ("C#", "15"));
			SkillList.Add (new Skills ("Parallel Programming", "5"));
			SkillList.Add (new Skills ("Design", "1"));*/

			////if (IsInDesignMode)
			////{
			////    // Code runs in Blend --> create design time data.
			////}
			////else
			////{
			////    // Code runs "for real"
			////}


		}

	}
}