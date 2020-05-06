using Application.Abstractions;
using Domain;

namespace DAL
{
    public class EFUnitOfWork : IUoW
    {
        private readonly PostgreDataContext _db;
        public EFUnitOfWork()
        {
            _db = new PostgreDataContext();
            Messages = new EFRepository<MessageEntity>(_db);
        }

        public IRepository<MessageEntity> Messages { get; set; }

        public void Dispose()
        {
            _db.Dispose();
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
