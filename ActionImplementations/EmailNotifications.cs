using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using InterfaceActions.Actions;

namespace ActionImplementations
{
    public class EmailNotifications : INotifyUsersAction
	{
		public void Notify(News news)
		{
			Console.WriteLine($"Send Email: News{news.Topic}");
		}
	}
}
