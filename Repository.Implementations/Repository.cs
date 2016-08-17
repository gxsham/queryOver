using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Domain;

namespace Repository.Implementations
{
	using Domain.Domain;
	using Infrastructure;
	using Interfaces;
	using NHibernate;
	public abstract class Repository<T> : IRepository<T> where T : Entity
	{
		protected readonly ISession _session = SessionGenerator.Instance.GetSession();

		public virtual void Delete(T entity)
		{
			using (ITransaction transaction = _session.BeginTransaction())
			{
				_session.Delete(entity);
				transaction.Commit();
			}
		}

		public virtual void Save(T entity)
		{
			using (ITransaction transaction = _session.BeginTransaction())
			{
				_session.SaveOrUpdate(entity);
				transaction.Commit();
			}
		}


	}
}
