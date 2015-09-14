using System;

namespace QUTBraingear
{
	public class Skills
	{

		public string skillTitle { get; set; }
		public string skillPoints { get; set; } // Change to int?

		public Skills (string skillTitle = "", string skillPoints = "")
		{
			this.skillTitle = skillTitle;
			this.skillPoints = skillPoints;
		}
	}
}

