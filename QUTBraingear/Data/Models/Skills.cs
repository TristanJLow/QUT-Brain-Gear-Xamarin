using System;
using SQLite.Net.Attributes;

namespace QUTBraingear.Data
{
	public class Skills
	{
		[PrimaryKey, AutoIncrement]
		public int skillId { get; set; }
		[NotNull, MaxLength(64)]
		public string skillTitle { get; set; }
		public string skillPoints { get; set; } // Change to int?

		public Skills()
		{
		}

		public Skills (string skillTitle = "", string skillPoints = "")
		{
			this.skillTitle = skillTitle;
			this.skillPoints = skillPoints;
		}
	}
}

