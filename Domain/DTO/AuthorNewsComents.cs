using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class AuthorNewsComents
	{
		public virtual long AuthorId { get; set; }
		public virtual string AuthorName { get; set; }
		public virtual long NewsId { get; set; }
		public virtual string NewsTopic { get; set; }
		public virtual long  CommentId { get; set; }
		public virtual string CommentText { get; set; }

		public AuthorNewsComents()
		{

		}

		public override string ToString()
		{
			return $"AuthorID:{AuthorId}\tAuthorName:{AuthorName}\tNewsId:{NewsId}\tNewsTopic:{NewsTopic}\tCommentId:{CommentId}\tComment:{CommentText}";
		}
	}
}
