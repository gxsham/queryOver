using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
	class AuthorMaping : EntityMap<Author>
    {
		public AuthorMaping()
		{
			Map(x => x.FirstName).Not.Nullable();
			Map(x => x.LastName).Not.Nullable();
			Map(x => x.Rating).Not.Nullable();
            Map(x => x.Age).Not.Nullable();
			Map(x => x.Description).Nullable();
			HasMany(x => x.News).Cascade.SaveUpdate().Inverse().ForeignKeyCascadeOnDelete().Not.KeyNullable();
			References(x => x.Role).Cascade.SaveUpdate().Not.Nullable();
		}
	}
}
