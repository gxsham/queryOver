using System;
using System.Collections.Generic;
using Domain.Domain;
using Factories;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using Repository.Interfaces;
using Infrastructure;
using Domain;
using System.Linq;

namespace NHibernate
{
	public class Program
	{
		private static AuthorFactory AuthorFactory;
		private static NewsFactory NewsFactory;
		private static CommentFactory CommentFactory;

		public static UserRole AdminRole = new UserRole(Roles.Admin);
		public static UserRole AuthorRole = new UserRole(Roles.Author);


		public static Random rnd = new Random();

		static void Main(string[] args)
		{App_Start.NHibernateProfilerBootstrapper.PreStart();

			App_Start.NHibernateProfilerBootstrapper.PreStart();

			//Seed();



			Queries();

			Console.ReadKey();
		}


		public static void Seed()
		{
			Random rndInt = new Random();
			Random rndString = new Random();
			var nRepository = ServiceLocator.Get<INewsRepository>();
			var crepository = ServiceLocator.Get<ICommentRepository>();
			var aRepository = ServiceLocator.Get<IAuthorRepository>();

			List<UserRole> rolesList = new List<UserRole>();
			rolesList.Add(new UserRole(Roles.Admin));
			rolesList.Add(new UserRole(Roles.Author));

			List<NewsCategory> categoryList = new List<NewsCategory>();
			categoryList.Add(new NewsCategory(Category.Entertainment));
			categoryList.Add(new NewsCategory(Category.International));
			categoryList.Add(new NewsCategory(Category.IT));
			categoryList.Add(new NewsCategory(Category.Political));
			categoryList.Add(new NewsCategory(Category.Social));
			categoryList.Add(new NewsCategory(Category.Sport));

			for (int i = 0; i < 100; i++)
			{
				var author = AuthorFactory.CreateNewAuthor(RandomString(rndString.Next(5, 10)), RandomString(rndString.Next(5, 10)), rolesList[rndInt.Next(0, 2)], rndInt.Next(1, 100), RandomString(rndString.Next(1,5)));
				aRepository.Save(author);
				for (int j = 0; j < rndInt.Next(10); j++)
				{
					var news = NewsFactory.CreateNewNews(RandomString(rndString.Next(1,5)), categoryList[rndInt.Next(0, 6)], author);
					nRepository.Save(news);
					for (int z = 0; z < rndInt.Next(5); z++)
					{
						var comment = CommentFactory.CreateNewComment(author, news, RandomString(rndString.Next(5, 10)));
						crepository.Save(comment);

					}
				}
			}
			Console.WriteLine("Seed Finished");
		}


		public static string RandomString(int length)
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			return new string(Enumerable.Repeat(chars, length)
			  .Select(s => s[rnd.Next(s.Length)]).ToArray());
		}

		public static void Queries()
		{
			var aRepository = ServiceLocator.Get<IAuthorRepository>();
			var nRepository = ServiceLocator.Get<INewsRepository>();

			//var cRepository = ServiceLocator.Get<ICommentRepository>();

			//Console.WriteLine(aRepository.GetFirstAuthor().ToString());

			//Console.WriteLine($"MaxAuthorAge:{aRepository.GetOldestAge()}");

			//var list = aRepository.GetAuthorsWithStartingLetter("C%");
			//foreach (var item in list)
			//{
			//	Console.WriteLine(item);
			//}

			//var list = aRepository.GetAllAuthorsYoungerThanWithNews(18,500);
			//foreach (var item in list)
			//{
			//	Console.WriteLine(item);
			//}

			//var list = aRepository.GetAuthorRatingFromNews();
			//foreach (var item in list)
			//{
			//	Console.WriteLine(item);
			//}

			//var list = aRepository.GetAuthorAndRating();
			//foreach (var item in list)
			//{
			//	Console.WriteLine(item);
			//}

			//aRepository.GetAllRolesAndCategories();

			//aRepository.GellNewsAndCateogryCount();

			//var list = aRepository.GetAllAuthorsNewsComments();
			//foreach (var item in list)
			//{
			//	Console.WriteLine(item);
			//}

			//var list = aRepository.GetUnderAgedNegativeCommenters();
			//foreach (var item in list)
			//{
			//	Console.WriteLine(item);
			//}

			//var list = aRepository.GetActivityStatus();
			//foreach (var item in list)
			//{
			//	Console.WriteLine(item);
			//}

			//var list = aRepository.GetAllAuthorsWithoutNews();
			//foreach (var item in list)
			//{
			//	Console.WriteLine(item);
			//}

			//var list = aRepository.GetAllNewsWithSomeText();
			//foreach (var item in list)
			//{
			//	Console.WriteLine(item);
			//}

			var list = aRepository.GetAllAuthorsWithRatingGreaterThen();
			foreach (var item in list)
			{
				Console.WriteLine(item);
			}
		}

		static Program()
		{
			NHibernateProfiler.Initialize();
			ServiceLocator.RegisterAll();
			AuthorFactory = ServiceLocator.Get<AuthorFactory>();
			NewsFactory = ServiceLocator.Get<NewsFactory>();
			CommentFactory = ServiceLocator.Get<CommentFactory>();
		}
	}
}







