using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
	using Domain;
	using FluentNHibernate.Mapping;
    public abstract class EntityMap<TEntity> : ClassMap<TEntity> where TEntity : Entity
    {
		protected EntityMap()
		{
			Id(x => x.Id).GeneratedBy.Identity();
			DynamicUpdate();
		}
    }
}
