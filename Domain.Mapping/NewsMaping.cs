using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
namespace Domain.Mapping
{
	using Domain;
	public class NewsMaping : EntityMap<News>
	{
		public NewsMaping()
		{
			Map(x => x.Topic).Not.Nullable();
			Map(x => x.Text).Nullable();
			Map(x => x.Rating).Not.Nullable();
			Map(x => x.TimeAdded).Not.Nullable();
			References(x => x.Author).Not.Nullable();
			References(x => x.Category).Cascade.SaveUpdate().Not.Nullable();
			HasMany(x => x.Comment).Cascade.SaveUpdate().Inverse().ForeignKeyCascadeOnDelete().Not.KeyNullable();
		}
	}
}
