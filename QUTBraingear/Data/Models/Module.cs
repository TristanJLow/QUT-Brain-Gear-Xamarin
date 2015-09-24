﻿using System;
using System.Collections.ObjectModel;
using QUTBraingear.Data;

namespace QUTBraingear.Data
{
	public class Module {
		private int moduleID;
		private string videoURL;
		private ObservableCollection<Skills> moduleSkills = new ObservableCollection<Skills>();
		public ObservableCollection<Comment> moduleComments { get; private set; }

		public Module () {
			moduleID = 0;
			videoURL = null;
		}

		public Module (int moduleID) {
			moduleID = this.moduleID;
			videoURL = "https://www.youtube.com/embed/bFdP3_TF7Ks";
			moduleSkills.Add(new Skills ("Programming", "2"));
			moduleSkills.Add(new Skills("C#","1"));
			Comment test = new Comment ();
			test.commentText = "New Test Comment";
			moduleComments = new ObservableCollection<Comment>();
			moduleComments.Add (test);
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

