using System;
using SQLite.Net.Attributes;

namespace QUTBraingear.Data
{
	public class Comment
	{
		[PrimaryKey, AutoIncrement]
		public int commentId { get; set; }
		[Indexed]
		public int moduleId { get; set; }
		public string commentText { get; set; }

		public Comment () {
		}

		public Comment (int moduleId, string commentText) {
			this.moduleId = moduleId;
			this.commentText = commentText;
		}
	}
}

