using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using NHibernate;

namespace Repository.Implementations
{
	public class CommentRepository : Repository<Comment>, ICommentRepository
	{
     
        public void EditText(long id, string text)
		{
			using (ITransaction transaction = _session.BeginTransaction())
			{
				var comment = _session.Load<Comment>(id);
				comment.Text = text;
				transaction.Commit();
			}
		}

		public void AddRating(Int64 id, int rating)
		{
			using (ITransaction transaction = _session.BeginTransaction())
			{
				var comment = _session.Load<Comment>(id);
				comment.Rating += rating;
				transaction.Commit();
			}
		}
	}
}
