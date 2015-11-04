using System;
using System.Collections.ObjectModel;
using QUTBraingear.Data;
using Newtonsoft.Json;


namespace QUTBraingear.Data
{
	public class Module {
		public string id { get; set; }
		public string videoURL { get; set; }
		public string moduleTitle { get; set; }
		public string moduleDesc { get; set; }
		[JsonIgnore]
		public ObservableCollection<Skills> moduleSkills { get; set; }
		[JsonIgnore]
		public ObservableCollection<Comment> moduleComments { get; set; }

		public Module () {
			moduleTitle = "";
			videoURL = "";
			moduleDesc = "";
			moduleSkills = new ObservableCollection<Skills>();
			moduleSkills.Add(new Skills ("Programming", "2"));
			moduleSkills.Add(new Skills("C#","1"));
			moduleComments = new ObservableCollection<Comment>();
		}
	}
}