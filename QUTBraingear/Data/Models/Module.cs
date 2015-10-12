using System;
using System.Collections.ObjectModel;
using SQLite.Net.Attributes;
using QUTBraingear.Data;

namespace QUTBraingear.Data
{
	public class Module {
		[PrimaryKey, AutoIncrement]
		public int moduleID { get; set; }		
		private string videoURL;
		private string moduleTitle;
		private ObservableCollection<Skills> moduleSkills = new ObservableCollection<Skills>();
		public ObservableCollection<Comment> moduleComments { get; private set; }

		public Module () {
			moduleID = 0;
			videoURL = null;
		}

		public Module (int moduleID) {
			moduleID = this.moduleID;
			moduleTitle = "Testing title";
			videoURL = "https://www.youtube.com/embed/bFdP3_TF7Ks";
			moduleSkills.Add(new Skills ("Programming", "2"));
			moduleSkills.Add(new Skills("C#","1"));
			Comment test = new Comment ();
			test.commentText = "New Test Comment";
			moduleComments = new ObservableCollection<Comment>();
			moduleComments.Add (test);
		}

		public int ID {
			get {
				return moduleID;
			}
			set {
				moduleID = value;
			}
		}

		public string Video {
			get {
				return videoURL;
			}
			set {
				videoURL = value;
			}
		}

		public string Title {
			get {
				return moduleTitle;
			}
			set {
				moduleTitle = value;
			}
		}

		public ObservableCollection<Skills> Skills {
			get {
				return moduleSkills;
			}
		}
	}
}

