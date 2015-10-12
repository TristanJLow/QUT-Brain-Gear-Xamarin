using System;
using System.Collections.ObjectModel;
using SQLite.Net.Attributes;
using QUTBraingear.Data;

namespace QUTBraingear.Data
{
	public class Module {
		[PrimaryKey, AutoIncrement]
		public int moduleID { get; set; }
		public string videoURL { get; set; }
		public string moduleTitle { get; set; }
		[Ignore]
		public ObservableCollection<Skills> moduleSkills { get; set; }
		[Ignore]
		public ObservableCollection<Comment> moduleComments { get; set; }

		public Module () {
			moduleTitle = "Testing title";
			videoURL = "https://www.youtube.com/embed/bFdP3_TF7Ks";
			moduleSkills = new ObservableCollection<Skills>();
			moduleSkills.Add(new Skills ("Programming", "2"));
			moduleSkills.Add(new Skills("C#","1"));
			moduleComments = new ObservableCollection<Comment>();
		}
	}
}