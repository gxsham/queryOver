using Domain.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public enum Category
	{
		IT, Sport, International, Political, Social, Entertainment  
	}
	public class NewsCategory : Entity
	{
		public virtual Category Category { get; protected set; }

		public NewsCategory(Category category)
		{
			Category = category;
		}

		[Obsolete]
		protected NewsCategory()
		{ }

		public override string ToString()
		{
			return $"{Category.ToString()}";
		}
	}
}
