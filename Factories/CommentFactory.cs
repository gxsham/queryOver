using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories
{
	using Domain;
	public class CommentFactory
	{
		public Comment CreateNewComment(Author author, News news, string text)
		{
			if (string.IsNullOrWhiteSpace(text))
				throw new ArgumentException("Empty comment", nameof(text));
			if (ReferenceEquals(news, null))
				throw new ArgumentNullException("Null news reference", nameof(news));
			if (ReferenceEquals(author, null))
				throw new ArgumentNullException("Null author reference", nameof(author));

			var comment = new Comment(text, news, author);
			return comment;
		}
	}
}
