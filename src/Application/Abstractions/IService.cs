using Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Application.Abstractions
{
    public interface IService<T> where T: StorageEntity
    {
        T Get(int id);

        IEnumerable<T> GetAll();

        T Add(T businessEntity);

        void Delete(int id);

        T Edit(T businessEntity);
    }
}
