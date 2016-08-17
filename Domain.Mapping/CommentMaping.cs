using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
	public class CommentMaping : EntityMap<Comment>
	{
		public CommentMaping()
		{
			Map(x => x.Text).Not.Nullable();
			Map(x => x.Rating).Not.Nullable();
			Map(x => x.TimeAdded).Not.Nullable();
			References(x => x.News).Not.Nullable();
			References(x => x.Author).Not.Nullable();
		}
	}
}
