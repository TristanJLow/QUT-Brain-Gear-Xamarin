using System;

namespace QUTBraingear.Data
{
	public class QA
	{

		public string qaTitle { get; set; }
		public string dateOccurs { get; set; }

		public QA (string qaTitle = "", string dateOccurs = "")
		{
			this.dateOccurs = dateOccurs;
			this.qaTitle = qaTitle;
		}
	}
}

