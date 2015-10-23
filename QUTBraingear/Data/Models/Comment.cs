using System;

namespace QUTBraingear.Data
{
	public class Comment
	{
		public string id { get; set; }
		public string moduleId { get; set; }
		public string commentText { get; set; }

		public Comment () {
		}

		public Comment (string moduleId, string commentText) {
			this.moduleId = moduleId;
			this.commentText = commentText;
		}
	}
}

