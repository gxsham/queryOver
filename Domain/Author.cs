
using Newtonsoft.Json;
namespace Domain
{
	using Domain;
	using Newtonsoft.Json.Converters;
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	public class Author : Entity
	{
		public virtual string FirstName { get;  set; }
		public virtual string LastName { get;  set; }
		public virtual UserRole Role { get;  set; }
		public virtual long Rating { get;  set; }
		public virtual long Age { get;  set; }
		public virtual string Description { get;  set; }
		public virtual IList<News> News { get; protected set; }

		[Obsolete]
		protected Author()
		{
		}

		public Author(string fName, string lName, UserRole role,  long age, string description ="" )
		{
			FirstName = fName;
			LastName = lName;
			Role = role;
			Rating = 0;
			Age = age;
			Description = description;
			News = new List<News>();
		}

		public override string ToString()
		{
			return $"{Id,-3} | Fname:{FirstName, 10} | Lname:{LastName,10} | Role:{Role.Id, 1} | Rating:{Rating,4} | Age:{Age,2} | Description:{Description,10}";
		}
	}

	
}
