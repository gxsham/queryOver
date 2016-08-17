
namespace Domain
{
	using Domain;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Converters;
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	public class News : Entity
	{
		public virtual string Topic { get;  set; }
		public virtual NewsCategory Category { get;  set; }
		public virtual string Text { get; set; }
		public virtual long Rating { get; set; }
		public virtual DateTime TimeAdded { get; protected set; }
		public virtual Author Author { get; protected set; }
		public virtual IList<Comment> Comment { get; protected set; }

		[Obsolete]
		protected News()
		{
		}

		public News(string topic, NewsCategory category,  Author author, string text = "")
		{
			Topic = topic;
			Category = category;
			Rating = 0;
			TimeAdded = DateTime.Now;
			Author = author;
			Comment = new List<Comment>();
		}
		public override string ToString()
		{
			return $"{Id, -3} | Topic:{Topic, 10} | Category:{Category.Id, 4} | Text:{Text, 20} | Rating:{Rating, 4} | TimeAdded:{TimeAdded.ToShortDateString(), 8} | Author:{Author.Id, 2}";	
		}
	}
	
}
