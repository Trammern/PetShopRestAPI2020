using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.DomainServices
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Add(T entity);
        void Edit(T entity);
        void Remove(long id);
    }
}
