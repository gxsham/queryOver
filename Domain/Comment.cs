using Domain.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class Comment : Entity
	{
		public virtual string Text { get; set; }
		public virtual long Rating { get; set; }
		public virtual DateTime TimeAdded { get; set; }
		public virtual News News { get; protected set; }
		public virtual Author Author { get; protected set; }

		[Obsolete]
		protected Comment()
		{
		}
		
		public Comment(string text, News news, Author author)
		{
			Text = text;
			News = news;
			Author = author;
			Rating = 0; 
			TimeAdded = DateTime.Now;
		}

		public override string ToString()
		{
			
			return $"{Id,-3} | Text:{Text,20} | Rating:{Rating,4} | TimeAdded:{TimeAdded.ToShortDateString(),8} | News:{News.Id,3} | Author:{Author.Id,3}";
			
		}
	}
	
}
