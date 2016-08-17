using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
	class NewsCategoryMaping : EntityMap<NewsCategory>
	{
		public NewsCategoryMaping()
		{
			Map(x => x.Category).Not.Nullable();
		}
	}
}
