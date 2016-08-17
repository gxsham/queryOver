using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
	public interface ICommentRepository : IRepository<Comment>
	{
		void EditText(long id, string text);
		void AddRating(Int64 id, int rating);
	}
}
