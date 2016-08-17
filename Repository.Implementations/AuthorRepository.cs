using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using NHibernate.Transform;
using Domain.DTO;
using NHibernate.Dialect.Function;

namespace Repository.Implementations
{
	public class AuthorRepository : Repository<Author>, IAuthorRepository
	{


		public void EditFirstName(long id, string newName)
		{
			using (ITransaction transaction = _session.BeginTransaction())
			{
				var author = _session.Load<Author>(id);
				author.FirstName = newName;
				transaction.Commit();
			}
		}

		public void EditLastName(long id, string newName)
		{
			using (ITransaction transaction = _session.BeginTransaction())
			{
				var author = _session.Load<Author>(id);
				author.LastName = newName;
				transaction.Commit();
			}
		}

		public void EditRole(long id, Roles newRole)
		{
			using (ITransaction transaction = _session.BeginTransaction())
			{
				var author = _session.Load<Author>(id);
				author.Role = new UserRole(newRole);
				transaction.Commit();
			}
		}


		public void EditAge(long id, int newAge)
		{
			using (ITransaction transaction = _session.BeginTransaction())
			{
				var author = _session.Load<Author>(id);
				author.Age = newAge;
				transaction.Commit();
			}
		}

		public void EditDescription(long id, string newDecription)
		{
			using (ITransaction transaction = _session.BeginTransaction())
			{
				var author = _session.Load<Author>(id);
				author.Description = newDecription;
				transaction.Commit();
			}
		}



		//Get first author
		// simple select
		public Author GetFirstAuthor()
		{
			return _session.QueryOver<Author>().Where(x => x.Id == 1).SingleOrDefault<Author>();
		}

		//Get the oldest age from authors
		// agregate
		public int GetOldestAge()
		{
			return _session.Query<Author>().Max(x => (int)x.Age);
		}

		//get the list of authors that name start with given letter
		// restrictions
		public IList<Author> GetAuthorsWithStartingLetter(string firstLetter)
		{
			return _session.QueryOver<Author>()
				.WhereRestrictionOn(c => c.FirstName).IsLike(firstLetter)
				.List<Author>();
		}

		//get all author younger than given age, that have news with rating greater than given
		//use join alias, transformers, alias
		public IList<Author> GetAllAuthorsYoungerThanWithNews(int age, int newsRating)
		{
			Author authorAllias = null;
			News newsAllias = null;

			return _session.QueryOver( ()=>authorAllias)
				.JoinAlias(() => authorAllias.News, () => newsAllias)				
				.TransformUsing(Transformers.DistinctRootEntity)
				.Where(() => authorAllias.Age <= age )
				.Where(() => newsAllias.Rating > newsRating)
				.List<Author>();
		}
		
		//get all authors rating based on their news rating 
		// use joinqueryover, selectlist, alias, aliastobeen, DTO
		public IList<AuthorRating> GetAuthorRatingFromNews()
		{
			AuthorRating authorRating = null;
			News newsAlias = null;
			return _session.QueryOver<Author>()
				.JoinQueryOver(n => n.News, ()=>newsAlias)
				.SelectList(list => list
					.SelectGroup(n => n.Id).WithAlias(()=> authorRating.Author)
					.SelectSum(()=>newsAlias.Rating).WithAlias(() => authorRating.Rating))
					.TransformUsing(Transformers.AliasToBean<AuthorRating>())
				.List<AuthorRating>();
		}

		//get all authors id and ratings in new object
		// use projections, alias, projection list and property, aliastobean
		public IList<AuthorRating> GetAuthorAndRating()
		{
			Author authorAllias = null;
			AuthorRating arAllias = null;
			return _session.QueryOver(() => authorAllias)
				.Select(Projections.ProjectionList()
				.Add(Projections.Property(() => authorAllias.Id).WithAlias(() => arAllias.Author))
				.Add(Projections.Property(() => authorAllias.Rating).WithAlias(() => arAllias.Rating))
				).TransformUsing(Transformers.AliasToBean<AuthorRating>())
				.List<AuthorRating>();
		}

		//Get all news  and Categories in one round trip; future
		// future
		public void GetAllRolesAndCategories()
		{
			IEnumerable<News> news = _session.QueryOver<News>().Future<News>();
			IEnumerable<NewsCategory> cateogries = _session.QueryOver<NewsCategory>().Future<NewsCategory>();

			int count = news.Count();
			Console.WriteLine(count);
		}

		//future value , get all news and count of categorys in one round trip
		//future value
		public void GellNewsAndCateogryCount()
		{
			IEnumerable<News> news = _session.QueryOver<News>().Future<News>();
			IFutureValue<int> categoryCount = _session.QueryOver<NewsCategory>()
				.SelectList(list =>
				list.SelectCount(x => x.Id))
				.FutureValue<int>();

			Console.WriteLine(categoryCount.Value);
		}

		//print all authors with their news and comments to their news
		// multiple joins, aliastobean
		public IList<AuthorNewsComents> GetAllAuthorsNewsComments()
		{
			Author authorAlias = null;
			News newsAlias = null;
			Comment commentAlias = null;
			AuthorNewsComents ancAlias = null;
			return _session.QueryOver(() => authorAlias)
				.JoinQueryOver(a => a.News, () => newsAlias)
				.JoinQueryOver(n => n.Comment, () => commentAlias)
				.Select(Projections.ProjectionList()
					.Add(Projections.Property(() => authorAlias.Id).WithAlias(() => ancAlias.AuthorId))
					.Add(Projections.Property(() => authorAlias.FirstName).WithAlias(() => ancAlias.AuthorName))
					.Add(Projections.Property(() => newsAlias.Id).WithAlias(() => ancAlias.NewsId))
					.Add(Projections.Property(() => newsAlias.Topic).WithAlias(() => ancAlias.NewsTopic))
					.Add(Projections.Property(() => commentAlias.Id).WithAlias(() => ancAlias.CommentId))
					.Add(Projections.Property(() => commentAlias.Text).WithAlias(() => ancAlias.CommentText)))
				.TransformUsing(Transformers.AliasToBean<AuthorNewsComents>())
				.List<AuthorNewsComents>();
		}

		//get all author that are yunger than 18 and used uncensored words
		// subquery, islike, in 
		public IList<Author> GetUnderAgedNegativeCommenters()
		{
			QueryOver<Comment> negativeComments =
				QueryOver.Of<Comment>()
				.Where(x=> x.Text.IsLike("%X%") || x.Text.IsLike("%Y%") || x.Text.IsLike("%Z%"))
				.Select(x => x.Author);

			return _session.QueryOver<Author>()
				.WithSubquery.WhereProperty(x => x.Id)
				.In(negativeComments)
				.Where(x=>x.Age<18)
				.List<Author>();
		}

		//Get activity of users, based on number of  articles
		//groupby projections, restrictions, aliastobean, conditional
		public IList<UserActivity> GetActivityStatus()
		{
			UserActivity activityAlias = null;
			News nAlias = null;
			return _session.QueryOver(()=>nAlias)
				.SelectList(
				list => list
					.SelectGroup(()=> nAlias.Author.Id).WithAlias(() => activityAlias.Author)
					.SelectCount(()=> nAlias.Id).WithAlias(() => activityAlias.ArticleNr)
					.Select(
							Projections.Conditional(
									Restrictions.Gt(Projections.Count(()=>nAlias.Id), 3),
									Projections.Constant("Active",NHibernateUtil.String),
									Projections.Constant("Inactive",NHibernateUtil.String)))
					.WithAlias(()=>activityAlias.Status))
					.OrderBy(Projections.Count(()=>nAlias.Id)).Desc
					.TransformUsing(Transformers.AliasToBean<UserActivity>())
					.List<UserActivity>();
		}

		//Get list of all authors that dont have news
		//Where exists, subquery
		public IList<Author> GetAllAuthorsWithoutNews()
		{
			Author aAlias = null;
			News nAlias = null;
			return _session.QueryOver(() => aAlias)
				.WithSubquery.WhereNotExists(
				QueryOver.Of(()=>nAlias).
				Where(()=> nAlias.Author.Id == aAlias.Id)
				.Select(n => n.Author.Id))
				.List<Author>();
		}

		//get all news with some text where text is null
		// using functions
		public IList<News> GetAllNewsWithSomeText()
		{
			News nAlias = null;

			return _session
				.QueryOver(() => nAlias)
				.SelectList(list =>
				list.Select(() => nAlias.Id).WithAlias(()=>nAlias.Id)
					.Select(() => nAlias.Topic).WithAlias(()=>nAlias.Topic)
					.Select(() => nAlias.Author).WithAlias(()=>nAlias.Author)
					.Select(() => nAlias.Category).WithAlias(()=>nAlias.Category)
					.Select(() => nAlias.Rating).WithAlias(()=>nAlias.Rating)
					.Select(() => nAlias.TimeAdded).WithAlias(()=>nAlias.TimeAdded)
					.Select(Projections.SqlFunction("coalesce",
					NHibernateUtil.String,
					Projections.Property(() => nAlias.Text),
					Projections.Constant("No Text Available", NHibernateUtil.String))).WithAlias(()=>nAlias.Text))
					.TransformUsing(Transformers.AliasToBean<News>())
					.List<News>();
		}

		//get All author with Rating more than average
		// create function
		public IList<Author> GetAllAuthorsWithRatingGreaterThen()
		{
			Author aAlias = null;
			var query = QueryOver.Of(() => aAlias)
				.Select(Projections.SqlFunction(
									new VarArgsSQLFunction("(", "/", ")"), NHibernateUtil.Int64,
									Projections.Sum(() => aAlias.Rating),
									Projections.Count(() => aAlias.Id)));

			return _session.QueryOver(() => aAlias)
				.OrderBy(()=>aAlias.Rating).Desc
				.WithSubquery
				.Where(() => aAlias.Rating > query.As<long>())
				.List<Author>();
		}
	}
}