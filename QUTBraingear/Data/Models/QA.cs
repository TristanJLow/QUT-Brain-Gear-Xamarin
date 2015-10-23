using System;

namespace QUTBraingear.Data
{
	public class QA
	{
		public string id { get; set; }
		public string qaTitle { get; set; }
		public string dateOccurs { get; set; }

		public QA () {
		}

		public QA (string qaTitle = "", string dateOccurs = "") {
			this.dateOccurs = dateOccurs;
			this.qaTitle = qaTitle;
		}
	}
}

