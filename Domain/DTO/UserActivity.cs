using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
	public class UserActivity
	{
		public virtual long Author { get; set; }
		public virtual long ArticleNr { get; set; }
		public virtual string Status { get; set; }

		public UserActivity()
		{

		}

		public override string ToString()
		{
			return $"AuthorId:{Author}\tArticleNumber:{ArticleNr}\tStatus:{Status}";
		}
	}
}
