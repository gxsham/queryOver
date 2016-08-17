using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories
{
	using Domain;

	public class AuthorFactory
	{
		public Author CreateNewAuthor(string fName, string lName, UserRole role, long age, string description = "")
		{

			if (string.IsNullOrWhiteSpace(fName))
				throw new ArgumentException("First name is required", nameof(fName));
			if (string.IsNullOrWhiteSpace(lName))
				throw new ArgumentException("Last name is required", nameof(lName));
			if (age <= 0 ||age > 150)
				throw new ArgumentException("Not valid age", nameof(age));
			if (ReferenceEquals(role, null))
				throw new ArgumentNullException("Null user role reference", nameof(role));

			var author = new Author(fName, lName,role, age, description);
			return author;
		}
	}
}

