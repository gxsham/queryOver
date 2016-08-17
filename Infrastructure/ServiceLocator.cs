using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Repository.Interfaces;
using Repository.Implementations;

namespace Infrastructure
{
    public static class ServiceLocator
    {
		public static void RegisterAll()
		{
			
			Kernel.Bind<INewsRepository>().To<NewsRepository>();
			Kernel.Bind<IAuthorRepository>().To<AuthorRepository>();
			Kernel.Bind<ICommentRepository>().To<CommentRepository>();
            
		}

		private static readonly IKernel Kernel = new StandardKernel();

		public static T Get<T>()
		{
			return Kernel.Get<T>();
		}
    }
}
