using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
	using Domain;
	using Interfaces;
	using NHibernate;
	public class NewsRepository : Repository<News>, INewsRepository
	{
		public void EditTopic(long id, string name)
		{
			using (ITransaction transaction = _session.BeginTransaction())
			{
				var news = _session.Load<News>(id);
				news.Topic = name;
				transaction.Commit();
			}
		}
		public void EditText(long id, string text)
		{
			using (ITransaction transaction = _session.BeginTransaction())
			{
				var news = _session.Load<News>(id);
				news.Text = text;
				transaction.Commit();
			}
		}

		public void EditCategory(long id, Category newCategory)
		{
			using (ITransaction transaction = _session.BeginTransaction())
			{
				var news = _session.Load<News>(id);
				news.Category = new NewsCategory(newCategory);
				transaction.Commit();
			}
		}
		public void AddRating(long id, int rating)
		{
			using (ITransaction transaction = _session.BeginTransaction())
			{
				var news = _session.Load<News>(id);
				news.Rating += rating;
				transaction.Commit();
			}
		}
	}
}
