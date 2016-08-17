using Domain.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public enum Roles
	{ Author, Admin }
	public class UserRole : Entity 
	{
		public virtual Roles Role { get; protected set; }

        public UserRole(Roles role = Roles.Author)
        {
            Role = role;
        }

        [Obsolete]
		protected UserRole()
		{
		}
		public override string ToString()
		{
			return $"{Role.ToString()}";
		}

	}
}
