using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories
{
	using Domain;
	

	public class NewsFactory
    {

		public News CreateNewNews(string topic, NewsCategory category, Author author, string text = "")
		{
			if (string.IsNullOrWhiteSpace(topic))
				throw new ArgumentException("Topic can not be empty", nameof(topic));
			if (ReferenceEquals(author,null))
				throw new ArgumentNullException("Null author reference",nameof(author));
			if (ReferenceEquals(author, null))
				throw new ArgumentNullException("Null category reference", nameof(category));

			var news = new News(topic, category, author, text);
			return news;
			
		}
	}

}

