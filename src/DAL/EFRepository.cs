using Application.Abstractions;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL
{
    public class EFRepository<T> : IRepository<T> where T : StorageEntity
    {
        private readonly DbContext _context;

        public EFRepository(PostgreDataContext context)
        {
            _context = context;
        }

        protected DbSet<T> Table => _context.Set<T>();

        public void Delete(int id)
        {
            var entity = Table.First(x => x.Id.Equals(id));
            Table.Remove(entity);
        }

        public T Get(int id) => Table.Any(x => x.Id.Equals(id)) ? Table.First(x => x.Id.Equals(id)) : null;

        public IQueryable<T> GetAll() => Table.AsQueryable();

        public T Insert(T entity)
        {
            Table.Add(entity);
            return entity;
        }

        public T Update(T entity)
        {
            Table.Update(entity);
            return entity;
        }
    }
}
