using System;
using SQLite.Net.Attributes;

namespace QUTBraingear.Data
{
	public class QA
	{
		[PrimaryKey, AutoIncrement]
		public int qaId { get; set; }
		[NotNull, MaxLength(64)]
		public string qaTitle { get; set; }
		public string dateOccurs { get; set; }

		public QA()
		{
		}

		public QA (string qaTitle = "", string dateOccurs = "")
		{
			this.dateOccurs = dateOccurs;
			this.qaTitle = qaTitle;
		}
	}
}

