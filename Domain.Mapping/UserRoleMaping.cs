using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
	public class UserRoleMaping : EntityMap<UserRole>
	{
		public UserRoleMaping()
		{
			Map(x => x.Role).Not.Nullable();
		}
	}
}
