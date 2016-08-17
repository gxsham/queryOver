using Domain;
using Domain.DTO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
	public interface IAuthorRepository : IRepository<Author>
	{
		void EditLastName(long id, string newName);
		void EditFirstName(long id, string newName);
		void EditRole(long id, Roles newRole);
		void EditAge(long id, int newAge);
		void EditDescription(long id, string newDecription);
		
		Author GetFirstAuthor();
		int GetOldestAge();
		IList<Author> GetAuthorsWithStartingLetter(string firstLetter);
		IList<Author> GetAllAuthorsYoungerThanWithNews(int age, int newsRating);
		IList<AuthorRating> GetAuthorRatingFromNews();
		IList<AuthorRating> GetAuthorAndRating();
		void GetAllRolesAndCategories();
		void GellNewsAndCateogryCount();
		IList<AuthorNewsComents> GetAllAuthorsNewsComments();
		IList<Author> GetUnderAgedNegativeCommenters();
		IList<UserActivity> GetActivityStatus();
		IList<Author> GetAllAuthorsWithoutNews();
		IList<News> GetAllNewsWithSomeText();
		IList<Author> GetAllAuthorsWithRatingGreaterThen();
	}
}
