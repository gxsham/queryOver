using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class AuthorRating
	{
		public virtual long Author { get; set; }
		public virtual long Rating { get; set; }


		public AuthorRating()
		{

		}

		public override string ToString()
		{
			return $"Author Id:{Author}\tRatingFromNews:{Rating}";
		}
	}
}
