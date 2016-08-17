using System.Reflection;
using Domain.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Util;

namespace Infrastructure
{
	public class SessionGenerator
	{

		public ISession GetSession()
		{
			return SessionFactory.OpenSession();
		}

		public static SessionGenerator Instance
		{
			get { return _sessionGenerator; }
		}



		private static ISessionFactory CreateSessionFactory()
		{
			FluentConfiguration configuration = Fluently.Configure()
														.Database(MsSqlConfiguration.MsSql2008
																					.ConnectionString(
																						builder =>
																						builder.Database(
																							"NHibernate")
																							   .Server(
																								   @"MDDSK40026\SQLEXPRESS")
																							   .TrustedConnection()))
														.Mappings(
															x =>
															{
																x.HbmMappings.AddFromAssembly(typeof(EntityMap<>).Assembly);
																x.FluentMappings.AddFromAssembly(typeof(EntityMap<>).Assembly);
															}

														   )
														.ExposeConfiguration(
															cfg => new SchemaUpdate(cfg).Execute(false, true));

			return configuration.BuildSessionFactory();
		}





		private SessionGenerator()
		{
		}

		private static readonly SessionGenerator _sessionGenerator = new SessionGenerator();
		private static readonly ISessionFactory SessionFactory = CreateSessionFactory();


	}
}