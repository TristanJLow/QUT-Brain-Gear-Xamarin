using System;
using System.Collections.ObjectModel;
using QUTBraingear.Data;

namespace QUTBraingear.Data
{
	public class Module {
		private int moduleID;
		private string videoURL;
		private ObservableCollection<Skills> moduleSkills = new ObservableCollection<Skills>();

		public Module () {
			moduleID = 0;
			videoURL = null;
			moduleSkills = null;
		}

		public Module (int moduleID) {
			moduleID = this.moduleID;
			videoURL = "https://www.youtube.com/embed/bFdP3_TF7Ks";
			moduleSkills.Add(new Skills ("Programming", "2"));
			moduleSkills.Add(new Skills("C#","1"));
		}

		public string Video {
			get {
				return videoURL;
			}
		}

		public ObservableCollection<Skills> Skills {
			get {
				return moduleSkills;
			}
		}
	}
}

