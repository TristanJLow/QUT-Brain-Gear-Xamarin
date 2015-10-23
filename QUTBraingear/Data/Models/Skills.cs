using System;

namespace QUTBraingear.Data
{
	public class Skills
	{
		public string id { get; set; }
		public string skillTitle { get; set; }
		public string skillPoints { get; set; } // Change to int?

		public Skills() {
		}

		public Skills (string skillTitle = "", string skillPoints = "") {
			this.skillTitle = skillTitle;
			this.skillPoints = skillPoints;
		}
	}
}

