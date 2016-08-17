using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
	public interface INewsRepository: IRepository<News>
	{
		void EditTopic(long id, string name);
		void EditText(long id, string text);
        void EditCategory(long id, Category newCategory);
		void AddRating(long id, int rating);

	}
}
