using InterfaceActions.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace ActionImplementations
{
	public class SmsNotification : INotifyUsersAction
	{
		public void Notify(News news)
		{
			Console.WriteLine($"Send Email: News{news.Topic}");
		}
	}
}
