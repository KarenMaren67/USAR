using System.Linq;

namespace Application.Abstractions
{
    public interface IRepository<T>
         where T : class
    {
        IQueryable<T> GetAll();

        T Get(int id);

        T Insert(T entity);

        void Delete(int id);

        T Update(T entity);
    }
}
