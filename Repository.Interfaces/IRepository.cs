using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Domain;

namespace Repository.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        void Save(T entity);

        void Delete(T entity);
    }
}
